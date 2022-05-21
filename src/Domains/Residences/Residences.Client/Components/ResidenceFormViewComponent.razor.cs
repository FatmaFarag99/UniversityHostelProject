namespace Residences.Client.Components;

public partial class ResidenceFormViewComponent
{
    [Parameter]
    public Guid ResidenceId { get; set; }
    [Parameter]
    public string SystemFeatureTypeParameter { get; set; }

    private SystemFeatureType systemFeatureType = SystemFeatureType.Add;
    private ResidenceViewModel residenceViewModel = new ResidenceViewModel();

    protected override async Task OnInitializedAsync()
    {
        systemFeatureType = (SystemFeatureType)Enum.Parse(typeof(SystemFeatureType), SystemFeatureTypeParameter, true);

        if (systemFeatureType.Equals(SystemFeatureType.Add))
            return;

        residenceViewModel = await _residenceHttpService.GetByIdAsync($"/api/residences/{ResidenceId.ToString()}");
    }
}
