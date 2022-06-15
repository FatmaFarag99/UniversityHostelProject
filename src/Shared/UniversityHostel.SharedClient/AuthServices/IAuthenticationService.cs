namespace UniversityHostel.SharedClient.AuthServices;

public interface IAuthenticationService
{
    Task<RegisterUserResponse> RegisterUser(string url, UserForRegisterViewModel userForRegister);
    Task<AuthResponseViewModel> Login(string url, UserForLoginViewModel userForLogin);
    Task Logout();
    Task<string> RefreshToken(string url);
}
