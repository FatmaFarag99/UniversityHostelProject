namespace Payments.Server.UnitOfWorks;

public class PaymentUnitOfWork : BaseUnitOfWork<Payment, PaymentViewModel>, IPaymentUnitOfWork
{
    public PaymentUnitOfWork(IPaymentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
