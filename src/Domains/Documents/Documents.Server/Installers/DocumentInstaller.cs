namespace Documents.Server.Services;

public class DocumentInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<DocumentViewModel>, DocumentValidator>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();
        services.AddScoped<IDocumentUnitOfWork, DocumentUnitOfWork>();
    }
}
