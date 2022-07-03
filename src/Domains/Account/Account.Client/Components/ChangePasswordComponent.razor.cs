namespace Account.Client.Components
{
    using System;
    using System.Threading.Tasks;

    public partial class ChangePasswordComponent
    {
        private readonly ChangePasswordViewModel changePasswordViewModel = new();

        private async Task ChangePassword()
        {
            try
            {
                bool isSuccess = await _authenticationService.ChangePassword("api/Account/change-password", changePasswordViewModel);

                if (isSuccess)
                {
                    _navigationManager.NavigateTo("/");
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                _toastService.ShowError(ex.Message);
            }
        }
    }
}