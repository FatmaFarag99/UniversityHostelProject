namespace UniversityHostel.SharedClient.AuthServices;

using System.Net.Http.Json;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;
    private readonly ILocalStorageService _localStorage;
    private readonly AuthenticationStateProvider _authStateProvider;

    public AuthenticationService(HttpClient httpClient, ILocalStorageService localStorage, AuthenticationStateProvider authStateProvider)
    {
        _httpClient = httpClient;
        _localStorage = localStorage;
        _authStateProvider = authStateProvider;
    }

    public async Task<RegisterUserResponse> RegisterUser(string url, UserForRegisterViewModel userForRegister)
    {
        string content = JsonConvert.SerializeObject(userForRegister);
        StringContent bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        HttpResponseMessage result = await _httpClient.PostAsync(url, bodyContent);
        string response = await result.Content.ReadAsStringAsync();
        
        if (!result.IsSuccessStatusCode)
        {
            RegisterUserResponse registerationResponse = JsonConvert.DeserializeObject<RegisterUserResponse>(response);
            return registerationResponse;
        }

        return new RegisterUserResponse { IsSucceeded = true };
    }

    public async Task<AuthResponseViewModel> Login(string url, UserForLoginViewModel userForLogin)
    {
        string content = JsonConvert.SerializeObject(userForLogin);
        StringContent bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

        HttpResponseMessage authResult = await _httpClient.PostAsync(url, bodyContent);
        string authContent = await authResult.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<AuthResponseViewModel>(authContent);

        if (!authResult.IsSuccessStatusCode)
            return result;

        await AuthenticateUserInClientApp(result);

        return new AuthResponseViewModel { IsAuthSuccessful = true };
    }
    private async Task AuthenticateUserInClientApp(AuthResponseViewModel authResponse)
    {
        if(authResponse is null)
            Console.WriteLine("Authentication not happen for client application becuase authResponse is null");

        await _localStorage.SetItemAsync<string>("AuthToken", authResponse.Token);
        await _localStorage.SetItemAsync<string>("RefreshToken", authResponse.RefreshToken);
        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(authResponse.Token);
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResponse.Token);

    }
    public async Task Logout()
    {
        await _localStorage.RemoveItemAsync("AuthToken");
        await _localStorage.RemoveItemAsync("RefreshToken");
        ((AuthStateProvider)_authStateProvider).NotifyUserLogout();
        _httpClient.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<string> RefreshToken(string url)
    {
        RefreshTokenViewModel refreshTokenViewModel = new RefreshTokenViewModel();

        refreshTokenViewModel.Token = await _localStorage.GetItemAsync<string>("AuthToken");
        refreshTokenViewModel.RefreshToken = await _localStorage.GetItemAsync<string>("RefreshToken");

        string content = JsonConvert.SerializeObject(refreshTokenViewModel);
        StringContent bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
        HttpResponseMessage refreshResult = await _httpClient.PostAsync(url, bodyContent);
        string refreshContent = await refreshResult.Content.ReadAsStringAsync();

        AuthResponseViewModel result = JsonConvert.DeserializeObject<AuthResponseViewModel>(refreshContent);

        if (!refreshResult.IsSuccessStatusCode)
        {
            Console.WriteLine(result.ErrorMessage);
        }

        await _localStorage.SetItemAsync("AuthToken", result.Token);
        await _localStorage.SetItemAsync("RefreshToken", result.RefreshToken);

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.Token);
         
        return result.Token;
    }

    public async Task ForgotPassword(string url, string email)
    {
        var forgotPasswordViewModel = new ForgotPasswordViewModel
        {
            Email = email
        };
        await _httpClient.PostAsJsonAsync(url, forgotPasswordViewModel);
    }

    public async Task<bool> ResetPassword(string url, ResetPasswordViewModel resetPasswordViewModel)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, resetPasswordViewModel);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> ChangePassword(string url, ChangePasswordViewModel changePasswordViewModel)
    {
        HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, changePasswordViewModel);
        return response.IsSuccessStatusCode;
    }
}