namespace Payments.Server.Controllers;

using Microsoft.AspNetCore.Authorization;
using Payments.Shared.ViewModels;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class PaymentsController : BaseController<Payment, PaymentViewModel>
{
    private readonly IPaymentUnitOfWork _unitOfWork;
    private readonly IValidator<PaymentViewModel> _validator;

    public PaymentsController(IPaymentUnitOfWork unitOfWork, IValidator<PaymentViewModel> validator) : base(unitOfWork, validator)
    {
        _unitOfWork = unitOfWork;
        _validator = validator;
    }

    [HttpPost("Paid")]
    [Authorize(Roles = "User")]
    public async Task<IActionResult> ElectronicPayment(PaymentViewModel paymentViewModel)
    {
        if (paymentViewModel == null)
            return BadRequest("ViewModel can not be null");

        var result = _validator.Validate(paymentViewModel);
        if (!result.IsValid)
        {
            string text = string.Join("-", result.Errors.Select(e => e.ErrorMessage));
            throw new Exception("NonValid ViewModel Reason:" + text);
        }
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        string transactionId = await _unitOfWork.ElectronicPayment(paymentViewModel, userId);

        return Ok(transactionId);
    }

}
