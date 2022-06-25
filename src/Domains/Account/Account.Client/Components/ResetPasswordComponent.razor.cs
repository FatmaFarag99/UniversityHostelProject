namespace Account.Client.Components
{
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public partial class ResetPasswordComponent
    {
        private readonly ResetPasswordViewModel resetPasswordViewModel = new();

        protected override void OnInitialized()
        {
            Uri uri = _navigationManager.ToAbsoluteUri(_navigationManager.Uri);
            Dictionary<string, StringValues> queryStrings = QueryHelpers.ParseQuery(uri.Query);
            resetPasswordViewModel.Code = queryStrings.TryGetValue("code", out var result) ? result.FirstOrDefault() : resetPasswordViewModel.Code;

            base.OnInitialized();
        }

        private async Task ResetPassword()
        {
            try
            {
                bool isSuccess = await _authenticationService.ResetPassword("api/Account/resetPassword", resetPasswordViewModel);

                if (isSuccess)
                {
                    _navigationManager.NavigateTo("/login");
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