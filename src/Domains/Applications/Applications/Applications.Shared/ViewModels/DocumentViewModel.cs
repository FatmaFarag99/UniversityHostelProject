namespace Applications.Shared.ViewModels;

public class DocumentViewModel : BaseViewModel
{
    public string Name { get; set; }
    public string Extension { get; set; }
    public double Size { get; set; }
    public string Type { get; set; }
    public string Path { get; set; }
    //public byte[] Content { get; set; }
}
