namespace ApplicationSettings.Shared.ViewModels;

public class ApplicationSettingViewModel : BaseViewModel
{
    public DateTime PhaseEndTime { get; set; } = DateTime.Now;
    public bool IsRegistrationEnabled { get; set; }
}
