namespace ApplicationSettings.Server.UnitOfWorks;

public class ApplicationSettingUnitOfWork : BaseSettingUnitOfWork<ApplicationSetting, ApplicationSettingViewModel>, IApplicationSettingUnitOfWork
{
    public ApplicationSettingUnitOfWork(IApplicationSettingRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
