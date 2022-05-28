namespace Documents.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : BaseController<Document, DocumentViewModel>
{
    public DocumentsController(IDocumentUnitOfWork unitOfWork, IValidator<DocumentViewModel> validator) : base(unitOfWork, validator)
    {
    }
}
