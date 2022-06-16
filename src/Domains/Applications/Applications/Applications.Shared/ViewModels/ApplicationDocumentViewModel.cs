namespace Applications.Shared.ViewModels;

public class ApplicationDocumentViewModel : BaseViewModel
{
    public Guid ApplicationId { get; set; }

    public Guid DocumentId { get; set; }
    public DocumentViewModel Document { get; set; } = new DocumentViewModel();

    public ApplicationDocumentType Type { get; set; }
}