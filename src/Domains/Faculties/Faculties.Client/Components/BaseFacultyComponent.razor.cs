namespace Faculties.Client.Components;

public partial class BaseFacultyComponent
{
    [Parameter]
    public FacultyViewModel FacultyViewModel { get; set; } = new FacultyViewModel();
    [Parameter]
    public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

    private async Task HandleValidSubmit()
    {
        string successMessage = string.Empty;
        if (SystemFeatureType.Equals(SystemFeatureType.Add))
        {
            FacultyViewModel = await _facultyHttpService.PostAsync("/api/faculties", FacultyViewModel);
            successMessage = "Faculty Added Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Edit))
        {
            FacultyViewModel = await _facultyHttpService.PutAsync("/api/faculties", FacultyViewModel);
            successMessage = "Faculty Edited Successfuly";
        }
        else if (SystemFeatureType.Equals(SystemFeatureType.Delete))
        {
            FacultyViewModel = await _facultyHttpService.DeleteAsync($"/api/faculties/{FacultyViewModel.Id}");
            successMessage = "Faculty Deleted Successfuly";
        }
        _toastService.ShowSuccess(successMessage);
        _navigationManager.NavigateTo("/faculties");
    }
}
