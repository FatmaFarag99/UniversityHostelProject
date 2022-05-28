namespace Applications.Client.Components;

public partial class BaseApplicationComponent
{
    [Parameter]
    public ApplicationViewModel ApplicationViewModel { get; set; } = new ApplicationViewModel()
    {
        Payment = new PaymentViewModel(),
        CreditCard = new CreditCardViewModel()
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
