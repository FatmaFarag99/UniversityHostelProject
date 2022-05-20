namespace Residences.Client.Components;

public partial class BaseResidenceComponent
{
    [Parameter]
    public ResidenceViewModel ResidenceViewModel { get; set; } = new ResidenceViewModel();
    [Parameter]
    public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

    private async Task HandleValidSubmit()
    {
        string successMessage = string.Empty;
        if (SystemFeatureType.Equals(SystemFeatureType.Add))
        {
            ResidenceViewModel = await _residenceHttpService.PostAsync("/api/residences", ResidenceViewModel);
            successMessage = "Residence Added Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Edit))
        {
            ResidenceViewModel = await _residenceHttpService.PutAsync("/api/residences", ResidenceViewModel);
            successMessage = "Residence Edited Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Delete))
        {
            ResidenceViewModel = await _residenceHttpService.DeleteAsync($"/api/residences/{ResidenceViewModel.Id}");
            successMessage = "Residence Deleted Successfuly";
        }
        _toastService.ShowSuccess(successMessage);
        _navigationManager.NavigateTo("/residences");
    }
}
