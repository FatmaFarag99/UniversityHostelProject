namespace Applications.Shared.ViewModels;

public class ApplicationDocumentViewModel
{
    public Guid ApplicationId { get; set; }

    public Guid DocumentId { get; set; }
    public DocumentViewModel Document { get; set; }
}
