namespace Documents.Server.Entities;

public class Document : BaseEntity
{
    public Guid ApplicationId { get; set; }
    public string Name { get; set; }
    public string Extension { get; set; }
    public double Size { get; set; }
    public string Path { get; set; }
    //public byte[] Content { get; set; }
}
