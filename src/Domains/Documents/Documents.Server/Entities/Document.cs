namespace Documents.Server.Entities;

public class Document : BaseEntity
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }
    //public string Path { get; set; }
    public byte[] Content { get; set; }
}