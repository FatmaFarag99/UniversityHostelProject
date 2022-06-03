namespace Payments.Server.Services;

public class PaymentInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<PaymentViewModel>, PaymentValidator>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentUnitOfWork, PaymentUnitOfWork>();
        services.AddScoped<IThirdPartyPaymentService, FakeThirdPartyPaymentService>();
    }
}
