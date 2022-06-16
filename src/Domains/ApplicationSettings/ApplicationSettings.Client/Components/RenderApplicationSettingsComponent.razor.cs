namespace ApplicationSettings.Client.Components;

public partial class RenderApplicationSettingsComponent
{
    private IEnumerable<ApplicationSettingViewModel> applicationSettings;
    private bool dataLoaded;
    protected override async Task OnInitializedAsync() => await GetApplicationSettings();

    private async Task GetApplicationSettings()
    {
        try
        {
            applicationSettings = await _applicationSettingHttpService.GetAsync("/api/applicationSettings");
            dataLoaded = true;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
