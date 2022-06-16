namespace ApplicationSettings.Client.Components;

public partial class ApplicationSettingFormViewComponent
{
    [Parameter]
    public Guid ApplicationSettingId { get; set; }
    [Parameter]
    public string SystemFeatureTypeParameter { get; set; }

    private SystemFeatureType systemFeatureType = SystemFeatureType.Add;
    private ApplicationSettingViewModel applicationSettingViewModel = new ApplicationSettingViewModel();

    protected override async Task OnInitializedAsync()
    {
        systemFeatureType = (SystemFeatureType)Enum.Parse(typeof(SystemFeatureType), SystemFeatureTypeParameter, true);

        if (systemFeatureType.Equals(SystemFeatureType.Add))
            return;

        applicationSettingViewModel = await _applicationSettingHttpService.GetByIdAsync($"/api/applicationSettings/{ApplicationSettingId.ToString()}");
    }
}
