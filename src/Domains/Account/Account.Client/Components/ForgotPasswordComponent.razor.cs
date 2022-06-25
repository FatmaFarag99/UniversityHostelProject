namespace Account.Client.Components
{
    using System;
    using System.Threading.Tasks;

    public partial class ForgotPasswordComponent
    {
        private ForgotPasswordViewModel forgotPasswordViewModel = new ForgotPasswordViewModel();
        bool isSent;

        private async Task ForgotPassword()
        {
            try
            {
                await _authenticationService.ForgotPassword("api/Account/forgotPassword", forgotPasswordViewModel.Email);
                isSent = true;
            }
            catch (Exception ex)
            {
                _toastService.ShowError(ex.Message);
            }
        }
    }
}