namespace Documents.Server.Repositories;

public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ApplicationContext context) : base(context)
    {
    }
}
