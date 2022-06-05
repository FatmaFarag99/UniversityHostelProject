namespace Applications.Shared.ViewModels;

using System.Reflection.Metadata;

public class ApplicationDocument
{
    public Guid ApplicationId { get; set; }

    public Guid DocumentId { get; set; }
    public Document Document { get; set; }
}
