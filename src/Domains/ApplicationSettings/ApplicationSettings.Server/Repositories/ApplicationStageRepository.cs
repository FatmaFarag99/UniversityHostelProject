namespace ApplicationSettings.Server.Repositories;

public class ApplicationStageRepository : BaseRepository<ApplicationStage>, IApplicationStageRepository
{
    public ApplicationStageRepository(ApplicationContext context) : base(context)
    {
    }
}
