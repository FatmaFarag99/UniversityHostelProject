namespace Applications.Server.Entities;

public class ApplicationDocument : BaseEntity
{
    public Guid ApplicationId { get; set; }

    public Guid DocumentId { get; set; }
    public Document Document { get; set; }

    public ApplicationDocumentType Type { get; set; }
}