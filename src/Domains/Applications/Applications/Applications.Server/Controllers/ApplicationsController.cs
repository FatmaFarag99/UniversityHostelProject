namespace Applications.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApplicationsController : BaseController<Application, ApplicationViewModel>
{
    public ApplicationsController(IApplicationUnitOfWork unitOfWork, IValidator<ApplicationViewModel> validator) : base(unitOfWork, validator)
    {
    }
}
