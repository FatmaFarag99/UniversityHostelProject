namespace Account.Client.Components;

public partial class RegisterComponent
{
    private UserForRegisterViewModel userForRegister = new UserForRegisterViewModel();
    private bool showErrors;
    private bool showSuccess;
    private IEnumerable<string> errors;
    private async Task RegisterUser()
    {

        showErrors = false;
        showSuccess = false;

        try
        {
            var response = await _authenticationService.RegisterUser("api/Account/RegisterUser", userForRegister);
            if (!response.IsSucceeded)
            {
                errors = response.Errors;
                showErrors = true;
            }
            else
            {
                var userForLogin = new UserForLoginViewModel
                {
                    UserName = userForRegister.UserName,
                    Password = userForRegister.Password
                };
                var authResponse = await _authenticationService.Login("api/Account/Login", userForLogin);
                string successMessage = "Welcome, you are registered successfully!";

                _toastService.ShowSuccess(successMessage);
                _navigationManager.NavigateTo("/");
            }
        }
        catch (Exception ex)
        {
            _toastService.ShowError(ex.Message);
        }
    }
}
