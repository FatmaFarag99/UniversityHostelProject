namespace Applications.Shared.ViewModels
{
    public class ApplicationResultViewModel : BaseViewModel
    {
        public string Message { get; set; }
        public ApplicationStatus Status { get; set; }
        public bool HasApplication { get; set; }
    }
}
