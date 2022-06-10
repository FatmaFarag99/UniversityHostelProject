namespace Applications.Client.Components
{
    using Applications.Shared.Enums;
    using Applications.Shared.ViewModels;
    using Documents.Shared.ViewModels;
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Payments.Shared.ViewModels;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using UniversityHostel.SharedClient;

    public partial class ApplicationForm
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

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

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            PaymentViewModel payment = await _paymentHttpService.GetByIdAsync("/api/applications/GetUnlinkedPayment/");
            ApplicationViewModel.PaymentId = payment.Id;
            ApplicationViewModel.Step = ApplicationStep.BasicInformation;

        }

        private async Task HandleValidSubmit()
        {
            string successMessage = string.Empty;
            if (SystemFeatureType.Equals(SystemFeatureType.Add))
            {
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

        private async Task HandlePayment(PaymentViewModel payment)
        {
            await Pay(payment);

            await CreateApplication();

            StateHasChanged();
        }

        private async Task Pay(PaymentViewModel payment)
        {
            payment.TransactionId = Guid.NewGuid().ToString();
            payment = await _paymentHttpService.PostAsync("/api/payments", payment);
            ApplicationViewModel.PaymentId = payment.Id;
            ApplicationViewModel.Payment = null;
        }

        private async Task CreateApplication()
        {
            var application = new ApplicationViewModel
            {
                UserId = await GetUserId(),
                PaymentId = ApplicationViewModel.PaymentId,
                BasicInformation = null,
                Documents = null
            };
            ApplicationViewModel = await _applicationHttpService.PostAsync("/api/applications", application);
            //ApplicationViewModel.Step = Shared.Enums.ApplicationStep.BasicInformation;
            ApplicationViewModel.BasicInformation = new BasicInformationViewModel();
            ApplicationViewModel.Documents = new ApplicationDocumentsViewModel();
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

        private void GoToStep(ApplicationStep step)
        {
            ApplicationViewModel.Step = step;
            StateHasChanged();
        }

        private void GoToNextStep()
        {
            switch (ApplicationViewModel.Step)
            {
                case ApplicationStep.BasicInformation:
                    ApplicationViewModel.Step = ApplicationStep.Documents;
                    break;
                default:
                    break;
            }
            
            StateHasChanged();
        }
    }
}