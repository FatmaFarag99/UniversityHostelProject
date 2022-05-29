namespace Documents.Server.Entities;

using Applications.Server.Entities;

public class Document : BaseEntity
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public List<DocumentAttachment> Attachments { get; set; }
}
