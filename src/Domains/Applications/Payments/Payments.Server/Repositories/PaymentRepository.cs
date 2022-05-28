namespace Payments.Server.Repositories;

public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
{
    public PaymentRepository(ApplicationContext context) : base(context)
    {
    }
}
