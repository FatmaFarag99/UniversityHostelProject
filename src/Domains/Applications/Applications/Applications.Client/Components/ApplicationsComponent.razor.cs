namespace Applications.Client.Components;

public partial class ApplicationsComponent
{
    private IEnumerable<ApplicationViewModel> applications = new List<ApplicationViewModel>();
    private bool dataLoaded;
    protected override async Task OnInitializedAsync() => await GetApplications();

    private async Task GetApplications()
    {
        try
        {
            applications = await _applicationHttpService.GetAsync("/api/applications");
            dataLoaded = true;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
