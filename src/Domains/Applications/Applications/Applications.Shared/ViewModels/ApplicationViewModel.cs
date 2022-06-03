namespace Applications.Shared.ViewModels;

using Applications.Shared.Enums;
using BasicInformations.Shared;
using Documents.Shared.ViewModels;

public class ApplicationViewModel : BaseViewModel
{
    public ApplicationStatus Status { get; set; }
    public string UserId { get; set; }
    public bool IsComplete { get; set; }

    public Guid PaymentId { get; set; }
    
    public Guid BasicInformationId { get; set; }
    public BasicInformationViewModel BasicInformation { get; set; }

    public Guid DocumentsId { get; set; }
    public DocumentViewModel Documents { get; set; }

}
