namespace Documents.Shared.ViewModels;

public class DocumentViewModel : BaseViewModel
{
    public Guid ApplicationId { get; set; }
    public List<DocumentAttachmentViewModel> Attachments { get; set; }
}
