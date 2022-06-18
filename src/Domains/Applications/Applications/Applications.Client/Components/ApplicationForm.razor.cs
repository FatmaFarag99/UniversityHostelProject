namespace Applications.Client.Components
{
    using Applications.Shared.ViewModels;
    using ApplicationSettings.Shared.ViewModels;
    using Documents.Shared.ViewModels;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.JSInterop;
    using Payments.Shared.ViewModels;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using UniversityHostel.SharedClient;

    public partial class ApplicationForm
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Parameter]
        public ApplicationViewModel ApplicationViewModel { get; set; } = new ApplicationViewModel
        {
            Payment = new PaymentViewModel(),
            BasicInformation = new ApplicationBasicInformationViewModel(),
        };
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

        private bool _isPaymentCompleted;
        private bool _isAllowForCreateApplication = true;
        private bool dataLoaded;
        private ApplicationStageViewModel applicationStage;

        private async Task<bool> CheckIfAllowCreateApplication()
        {
            applicationStage = await _applicationStagesHttpService.GetByIdAsync("api/ApplicationStages/lastStage");
            if (applicationStage is null)
                return await Task.FromResult(false);

            return await Task.FromResult(applicationStage.StageStatus.Equals(StageStatus.Opened) && applicationStage.EndTime > DateTime.Now);
        }
        protected override async Task OnInitializedAsync()
        {
            _isAllowForCreateApplication = await CheckIfAllowCreateApplication();
            if (!_isAllowForCreateApplication)
                return;

            ApplicationViewModel application = await _applicationHttpService.GetByIdAsync($"/api/applications/GetPendingApplication");
            if (application != null)
            {
                _navigationManager.NavigateTo("/applications");
            }


            ApplicationViewModel.UserId = await GetUserId();
            ApplicationViewModel.ApplicationStageId = applicationStage.Id;

            PaymentViewModel payment = await _paymentHttpService.GetByIdAsync($"/api/applications/GetUnlinkedPayment");
            if(payment != null)
            {
                ApplicationViewModel.PaymentId = payment.Id;
                ApplicationViewModel.Payment = payment;

                _isPaymentCompleted = true;
            }

            dataLoaded = true;
            StateHasChanged();
        }

        private async Task HandleValidSubmit()
        {
            try
            {
                string successMessage = string.Empty;
                if (SystemFeatureType.Equals(SystemFeatureType.Add))
                {
                    ApplicationViewModel.Payment = null;

                    ApplicationViewModel = await _applicationHttpService.PostAsync("/api/applications", ApplicationViewModel);
                    successMessage = "Application Added Successfuly";
                }
                else if (SystemFeatureType.Equals(SystemFeatureType.Edit))
                {
                    ApplicationViewModel = await _applicationHttpService.PutAsync("/api/applications", ApplicationViewModel);
                    successMessage = "Application Edited Successfuly";
                }
                else if (SystemFeatureType.Equals(SystemFeatureType.Delete))
                {
                    ApplicationViewModel = await _applicationHttpService.DeleteAsync($"/api/applications/{ApplicationViewModel.Id}");
                    successMessage = "Application Deleted Successfuly";
                }
                _toastService.ShowSuccess(successMessage);
                _navigationManager.NavigateTo("/applications");
            }
            catch (Exception exception)
            {
                _toastService.ShowError(exception.Message);
                //throw;
            }
        }

        private async Task<string> GetUserId()
        {
            var authState = await AuthenticationState;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return null;
        }
    }
}