namespace Applications.Shared.ViewModels;

using Applications.Shared.Enums;

public class ApplicationViewModel : BaseViewModel
{
    public ApplicationStatus Status { get; set; }
    public string UserId { get; set; }
    public bool IsComplete { get; set; }
}
