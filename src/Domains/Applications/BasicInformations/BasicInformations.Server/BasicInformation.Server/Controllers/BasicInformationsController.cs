namespace BasicInformations.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BasicInformationsController : BaseController<BasicInformation, BasicInformationViewModel>
{
    public BasicInformationsController(IBasicInformationUnitOfWork unitOfWork, IValidator<BasicInformationViewModel> validator) : base(unitOfWork, validator)
    {
    }
}
