namespace BasicInformations.Server;

public class BasicInformationInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<BasicInformationViewModel>, BasicInformationValidator>();
        services.AddScoped<IBasicInformationRepository, BasicInformationRepository>();
        services.AddScoped<IBasicInformationUnitOfWork, BasicInformationUnitOfWork>();
    }
}
