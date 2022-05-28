namespace Payments.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : BaseController<Payment, PaymentViewModel>
{
    public PaymentsController(IPaymentUnitOfWork unitOfWork, IValidator<PaymentViewModel> validator) : base(unitOfWork, validator)
    {
    }
}
