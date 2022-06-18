namespace ApplicationSettings.Server.Entities;

public class ApplicationStage : BaseEntity
{
    public DateTime EndTime { get; set; }
    public StageStatus StageStatus { get; set; }
}
