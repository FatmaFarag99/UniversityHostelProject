namespace Applications.Server.Controllers;

using Applications.Shared.Enums;
using Microsoft.AspNetCore.Authorization;
using Payments.Server.UnitOfWorks;
using Payments.Shared.ViewModels;
using System.Security.Claims;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : BaseController<Application, ApplicationViewModel>
{
    private readonly IApplicationUnitOfWork _unitOfWork;
    private readonly IPaymentUnitOfWork _paymentUnitOfWork;
        
    public ApplicationsController(IApplicationUnitOfWork unitOfWork, IPaymentUnitOfWork paymentUnitOfWork, IValidator<ApplicationViewModel> validator) : base(unitOfWork, validator)
    {
        _unitOfWork = unitOfWork;
        _paymentUnitOfWork = paymentUnitOfWork;
    }

    [HttpGet("GetPendingApplication")]
    public virtual async Task<ApplicationViewModel> GetPendingApplication()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        ApplicationViewModel application = (await _unitOfWork.ReadByExpressionAsync(application => application.UserId == userId && application.Status.Equals(ApplicationStatus.Pending))).FirstOrDefault();

        return application;
    }

    [HttpGet("GetUnlinkedPayment")]
    public virtual async Task<PaymentViewModel> GetUnlinkedPaymentAsync()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        List<ApplicationViewModel> applications = (await _unitOfWork.ReadByExpressionAsync(application => application.UserId == userId)).ToList();

        IEnumerable<PaymentViewModel> userPayments = await _paymentUnitOfWork.ReadByExpressionAsync(payment => payment.UserId == userId);
        PaymentViewModel payment = userPayments.FirstOrDefault(payment => !applications.Any(application => application.PaymentId == payment.Id));

        return payment;
    }
    [HttpGet("Grid")]
    public async Task<IEnumerable<ApplicationGridViewModel>> GetForGrid() => await _unitOfWork.ReadForGrid();
    
    [HttpPost("Reject")]
    public async Task<ApplicationViewModel> Reject(ApplicationViewModel application) => await _unitOfWork.Reject(application);
    
    [HttpPost("Accept")]
    public async Task<ApplicationViewModel> Accept(ApplicationViewModel application) => await _unitOfWork.Accept(application);
}