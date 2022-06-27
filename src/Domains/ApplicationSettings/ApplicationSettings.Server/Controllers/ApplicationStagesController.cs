namespace ApplicationSettings.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationStagesController : BaseController<ApplicationStage, ApplicationStageViewModel>
{
    private readonly IApplicationStageUnitOfWork _unitOfWork;

    public ApplicationStagesController(IApplicationStageUnitOfWork unitOfWork, IValidator<ApplicationStageViewModel> validator) : base(unitOfWork, validator)
    {
        this._unitOfWork = unitOfWork;
    }

    [HttpGet("lastStage")]
    public async Task<IActionResult> GetLastStage() => Ok( await _unitOfWork.ReadLastStage());

    [HttpGet("SubmitStageResults/{stageId}")]
    public async Task<IActionResult> SubmitStageResults(Guid stageId) => Ok(await _unitOfWork.SubmitStageResults(stageId));
}
