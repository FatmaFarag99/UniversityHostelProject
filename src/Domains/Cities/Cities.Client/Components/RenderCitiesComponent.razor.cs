namespace Cities.Client.Components;

public partial class RenderCitiesComponent
{
    private IEnumerable<CityViewModel> cities;
    private bool dataLoaded;
    protected override async Task OnInitializedAsync() => await GetCities();

    private async Task GetCities()
    {
        try
        {
            cities = await _cityHttpService.GetAsync("/api/cities");
            dataLoaded = true;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
