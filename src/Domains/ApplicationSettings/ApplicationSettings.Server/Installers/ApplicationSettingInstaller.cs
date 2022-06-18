namespace ApplicationSettings.Server.Services;

public class ApplicationSettingInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<ApplicationSettingViewModel>, ApplicationSettingValidator>();
        services.AddScoped<IApplicationSettingRepository, ApplicationSettingRepository>();
        services.AddScoped<IApplicationSettingUnitOfWork, ApplicationSettingUnitOfWork>();

        services.AddScoped<IValidator<ApplicationStageViewModel>, ApplicationStageValidator>();
        services.AddScoped<IApplicationStageRepository, ApplicationStageRepository>();
        services.AddScoped<IApplicationStageUnitOfWork, ApplicationStageUnitOfWork>();
    }
}
