namespace ApplicationSettings.Server.UnitOfWorks;

public class ApplicationSettingUnitOfWork : BaseUnitOfWork<ApplicationSetting, ApplicationSettingViewModel>, IApplicationSettingUnitOfWork
{
    public ApplicationSettingUnitOfWork(IApplicationSettingRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
