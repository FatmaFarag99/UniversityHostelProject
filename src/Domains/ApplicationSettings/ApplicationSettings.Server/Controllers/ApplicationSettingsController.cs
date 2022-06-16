namespace ApplicationSettings.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationSettingsController : BaseController<ApplicationSetting, ApplicationSettingViewModel>
{
    public ApplicationSettingsController(IApplicationSettingUnitOfWork unitOfWork, IValidator<ApplicationSettingViewModel> validator) : base(unitOfWork, validator)
    {
    }
}
