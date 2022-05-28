namespace Documents.Server.UnitOfWorks;

public class DocumentUnitOfWork : BaseUnitOfWork<Document, DocumentViewModel>, IDocumentUnitOfWork
{
    public DocumentUnitOfWork(IDocumentRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
