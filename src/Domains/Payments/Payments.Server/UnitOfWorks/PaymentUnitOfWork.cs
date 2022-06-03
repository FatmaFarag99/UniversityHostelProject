namespace Payments.Server.UnitOfWorks;

using Payments.Server.Services;
using Payments.Server.Services.Models;
using System.Threading.Tasks;

public class PaymentUnitOfWork : BaseUnitOfWork<Payment, PaymentViewModel>, IPaymentUnitOfWork
{
    private readonly IPaymentRepository _repository;
    private readonly IThirdPartyPaymentService _paymentService;

    public PaymentUnitOfWork(IPaymentRepository repository, IMapper mapper, IThirdPartyPaymentService paymentService) 
        : base(repository, mapper)
    {
        _repository = repository;
        _paymentService = paymentService;
    }

    public async Task<string> ElectronicPayment(PaymentViewModel viewModel)
    {
        ThirdPartyResponse response = await _paymentService.SendPaidRequest("http://localhost:9999/ElectronicPayment", viewModel);
        if (!response.IsSuccess)
            throw new Exception("Payment fail, please try again later.");

        Payment payment = new Payment() 
        {
            TransactionId = response.TransactionId,
            PaidAmount = response.Amount 
        };
        await _repository.AddAsync(payment);
        await _context.SaveChangesAsync();

        return response.TransactionId;
    }
}
