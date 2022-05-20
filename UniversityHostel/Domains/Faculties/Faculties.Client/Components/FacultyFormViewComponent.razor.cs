namespace Faculties.Client.Components;

public partial class FacultyFormViewComponent
{
    [Parameter]
    public Guid FacultyId { get; set; }
    [Parameter]
    public string SystemFeatureTypeParameter { get; set; }

    private SystemFeatureType systemFeatureType = SystemFeatureType.Add;
    private FacultyViewModel facultyViewModel = new FacultyViewModel();

    protected override async Task OnInitializedAsync()
    {
        systemFeatureType = (SystemFeatureType)Enum.Parse(typeof(SystemFeatureType), SystemFeatureTypeParameter, true);

        if (systemFeatureType.Equals(SystemFeatureType.Add))
            return;

        facultyViewModel = await _facultyHttpService.GetByIdAsync($"/api/faculties/{FacultyId.ToString()}");
    }
}
