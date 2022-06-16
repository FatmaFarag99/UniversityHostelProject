namespace ApplicationSettings.Server.Entities;

public class ApplicationSetting : BaseEntity
{
    public DateTime PhaseEndTime { get; set; }
    public bool isRegistrationEnabled { get; set; }
}
