namespace Payments.Server.Services;

public class PaymentInstaller : IInstaller
{
    public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidator<PaymentViewModel>, PaymentValidator>();
        services.AddScoped<IValidator<CreditCardViewModel>, CreditCardValidator>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IPaymentUnitOfWork, PaymentUnitOfWork>();
    }
}
