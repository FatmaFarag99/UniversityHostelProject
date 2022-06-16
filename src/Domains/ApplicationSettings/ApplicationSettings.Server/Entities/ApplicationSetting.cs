namespace ApplicationSettings.Server.Entities;

public class ApplicationSetting : BaseEntity
{
    public DateTime PhaseEndTime { get; set; }
    public bool IsRegistrationEnabled { get; set; }
}
