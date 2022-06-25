namespace Applications.Server.Controllers;

using Applications.Shared.Enums;
using ApplicationSettings.Server.UnitOfWorks;
using ApplicationSettings.Shared.ViewModels;
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
    private readonly IApplicationStageUnitOfWork _applicationStageUnitOfWork;

    public ApplicationsController(IApplicationUnitOfWork unitOfWork, IPaymentUnitOfWork paymentUnitOfWork,
        IApplicationStageUnitOfWork applicationResultsUnitOfWork, IValidator<ApplicationViewModel> validator) : base(unitOfWork, validator)
    {
        _unitOfWork = unitOfWork;
        _paymentUnitOfWork = paymentUnitOfWork;
        _applicationStageUnitOfWork = applicationResultsUnitOfWork;
    }

    [HttpGet("result")]
    public async Task<ApplicationResultViewModel> GetApplicationResult()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        ApplicationStageViewModel applicationStage = await _applicationStageUnitOfWork.ReadLastStage();

        ApplicationViewModel application = (await _unitOfWork.ReadByExpressionAsync(application => application.UserId == userId && application.CreationDate < applicationStage.EndTime && application.CreationDate >= applicationStage.CreationDate)).FirstOrDefault();
        ApplicationResultViewModel applicationResult = new ApplicationResultViewModel();
        if (application == null)
        {
            applicationResult.Message = "You do not have any application request.";
            applicationResult.HasApplication = false;
        }
        else
        {
            applicationResult.HasApplication = true;
            TimeSpan remainingTime = (applicationStage.EndTime < DateTime.Now) ? TimeSpan.Zero : (applicationStage.EndTime - DateTime.Now);
            if (applicationStage.StageStatus.Equals(StageStatus.Opened) && remainingTime != TimeSpan.Zero)
            {
                applicationResult.Message = "Remaining time for stage is " + Math.Floor(remainingTime.TotalHours) + " hours";
                applicationResult.Status = ApplicationStatus.Pending;
            }
            else
            {
                applicationResult.Status = application.Status;
                if (application.Status == ApplicationStatus.Accepted)
                    applicationResult.Message = "Congratulations, your application has been accepted into the university hosel";
                else if (application.Status == ApplicationStatus.Rejected)
                    applicationResult.Message = "Unfortunately, your request has been rejected";
            }

        }

        return applicationResult;
    }

    [HttpGet("GetPendingApplication")]
    public async Task<ApplicationViewModel> GetPendingApplication()
    {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        ApplicationStageViewModel applicationStage = await _applicationStageUnitOfWork.ReadLastStage();

        ApplicationViewModel application = (await _unitOfWork.ReadByExpressionAsync(application => application.UserId == userId && (application.Status.Equals(ApplicationStatus.Pending) || (application.CreationDate >= applicationStage.CreationDate && application.CreationDate < applicationStage.EndTime)))).FirstOrDefault();

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