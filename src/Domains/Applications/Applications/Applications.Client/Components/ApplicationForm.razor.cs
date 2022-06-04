namespace Applications.Client.Components
{
    using Applications.Shared.ViewModels;
    using Microsoft.AspNetCore.Components;
    using Payments.Shared.ViewModels;
    using System.Threading.Tasks;
    using UniversityHostel.SharedClient;

    public partial class ApplicationForm
    {
        [Parameter]
        public ApplicationViewModel ApplicationViewModel { get; set; } = new ApplicationViewModel
        {
            Payment = new PaymentViewModel(),
            BasicInformation = new BasicInformationViewModel()
        };
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

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
    }
}
