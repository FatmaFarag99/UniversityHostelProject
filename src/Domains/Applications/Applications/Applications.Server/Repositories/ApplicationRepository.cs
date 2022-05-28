namespace Applications.Server.Repositories;

public class ApplicationRepository : BaseRepository<Application>, IApplicationRepository
{
    public ApplicationRepository(ApplicationContext context) : base(context)
    {
    }
}
