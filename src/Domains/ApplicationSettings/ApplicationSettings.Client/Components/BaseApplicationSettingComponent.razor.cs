namespace ApplicationSettings.Client.Components;

public partial class BaseApplicationSettingComponent
{
    [Parameter]
    public ApplicationSettingViewModel ApplicationSettingViewModel { get; set; } = new ApplicationSettingViewModel();
    [Parameter]
    public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

    private async Task HandleValidSubmit()
    {
        string successMessage = string.Empty;
        if (SystemFeatureType.Equals(SystemFeatureType.Add))
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.PostAsync("/api/applicationSettings", ApplicationSettingViewModel);
            successMessage = "ApplicationSetting Added Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Edit))
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.PutAsync("/api/applicationSettings", ApplicationSettingViewModel);
            successMessage = "ApplicationSetting Edited Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Delete))
        {
            ApplicationSettingViewModel = await _applicationSettingHttpService.DeleteAsync($"/api/applicationSettings/{ApplicationSettingViewModel.Id}");
            successMessage = "ApplicationSetting Deleted Successfuly";
        }
        _toastService.ShowSuccess(successMessage);
        _navigationManager.NavigateTo("/applicationSettings");
    }
}
