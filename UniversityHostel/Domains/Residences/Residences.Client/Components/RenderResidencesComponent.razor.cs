namespace Residences.Client.Components;

public partial class RenderResidencesComponent
{
    private IEnumerable<ResidenceViewModel> residences;
    private bool dataLoaded;
    protected override async Task OnInitializedAsync() => await GetResidences();

    private async Task GetResidences()
    {
        try
        {
            residences = await _residenceHttpService.GetAsync("/api/residences");
            dataLoaded = true;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
