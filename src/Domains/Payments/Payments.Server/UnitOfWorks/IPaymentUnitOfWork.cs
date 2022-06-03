namespace Payments.Server.UnitOfWorks;

public interface IPaymentUnitOfWork : IBaseUnitOfWork<Payment, PaymentViewModel>
{
    Task<string> ElectronicPayment(PaymentViewModel viewModel);
}
