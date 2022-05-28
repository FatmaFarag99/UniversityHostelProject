namespace Applications.Server.Services;

public class ApplicationInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<ApplicationViewModel>, ApplicationValidator>();
        services.AddScoped<IApplicationRepository, ApplicationRepository>();
        services.AddScoped<IApplicationUnitOfWork, ApplicationUnitOfWork>();
    }
}
