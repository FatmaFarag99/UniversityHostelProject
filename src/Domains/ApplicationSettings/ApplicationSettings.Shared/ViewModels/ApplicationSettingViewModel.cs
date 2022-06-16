namespace ApplicationSettings.Shared.ViewModels;

public class ApplicationSettingViewModel : BaseViewModel
{
    public DateTime PhaseEndTime { get; set; } = DateTime.Now;
    public bool isRegistrationEnabled { get; set; }
}
