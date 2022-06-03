namespace Documents.Shared.ViewModels;

public class DocumentAttachmentViewModel : BaseViewModel
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }
    public string Content { get; set; }
}
