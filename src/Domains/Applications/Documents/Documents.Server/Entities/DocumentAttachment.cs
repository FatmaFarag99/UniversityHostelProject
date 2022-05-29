namespace Documents.Server.Entities;

public class DocumentAttachment : BaseEntity
{
    public Guid DocumentId { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public double Size { get; set; }
    public string Content { get; set; }
    public string Type { get; set; }
}
