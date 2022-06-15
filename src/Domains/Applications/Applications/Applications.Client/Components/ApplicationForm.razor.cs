namespace Applications.Client.Components
{
    using Applications.Shared.Enums;
    using Applications.Shared.ViewModels;
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
            BasicInformation = new BasicInformationViewModel(),
            Documents = new ApplicationDocumentsViewModel
            {
                Document1 = new ApplicationDocumentViewModel
                {
                    Document = new DocumentViewModel()
                },
                Document2 = new ApplicationDocumentViewModel
                {
                    Document = new DocumentViewModel()
                },
                Document3 = new ApplicationDocumentViewModel
                {
                    Document = new DocumentViewModel()
                }
            }
        };
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

        private bool _isPaymentCompleted;
        private bool _isAllowForCreateApplication;

        private async Task<bool> CheckIfAllowCreateApplication()
        {
            // check if admin is allow to create application or not
            return await Task.FromResult(true);
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

            PaymentViewModel payment = await _paymentHttpService.GetByIdAsync($"/api/applications/GetUnlinkedPayment");
            if(payment != null)
            {
                ApplicationViewModel.PaymentId = payment.Id;
                ApplicationViewModel.Payment = payment;

                _isPaymentCompleted = true;
            }
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

        private readonly Dictionary<ApplicationStep, string> applicationStepsTabs = new()
        {
            { ApplicationStep.Payment, "payment" },
            { ApplicationStep.BasicInformation, "basic-information" },
            { ApplicationStep.Documents, "documents" }
        };

        private async Task GoToStep(ApplicationStep step)
        {
            ApplicationViewModel.Step = step;
            await JsRuntime.InvokeVoidAsync("activeTab", applicationStepsTabs[step]);
            StateHasChanged();
        }
    }
}