namespace Faculties.Client.Components;

public partial class RenderFacultiesComponent
{
    private IEnumerable<FacultyViewModel> faculties;
    private bool dataLoaded;
    protected override async Task OnInitializedAsync() => await GetFaculties();

    private async Task GetFaculties()
    {
        try
        {
            faculties = await _facultyHttpService.GetAsync("/api/faculties");
            dataLoaded = true;
            StateHasChanged();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
