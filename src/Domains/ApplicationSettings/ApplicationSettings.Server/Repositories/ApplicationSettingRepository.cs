namespace ApplicationSettings.Server.Repositories;

public class ApplicationSettingRepository : BaseRepository<ApplicationSetting>, IApplicationSettingRepository
{
    public ApplicationSettingRepository(ApplicationContext context) : base(context)
    {
    }
}
