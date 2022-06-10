namespace Applications.Server.Controllers;

using Payments.Server.UnitOfWorks;
using Payments.Shared.ViewModels;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : BaseController<Application, ApplicationViewModel>
{
    private readonly IPaymentUnitOfWork _paymentUnitOfWork;

    public ApplicationsController(IApplicationUnitOfWork unitOfWork, IPaymentUnitOfWork paymentUnitOfWork, IValidator<ApplicationViewModel> validator) : base(unitOfWork, validator)
    {
        _paymentUnitOfWork = paymentUnitOfWork;
    }

    [HttpGet("GetUnlinkedPayment/{userId}")]
    public virtual async Task<PaymentViewModel> GetUnlinkedPaymentAsync(string userId)
    {
        PaymentViewModel payment = (await _paymentUnitOfWork.ReadByExpressionAsync(payment => payment.UserId == userId)).FirstOrDefault();
        return payment;
    }
}
