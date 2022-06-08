namespace Applications.Shared.ViewModels;

using Applications.Shared.Enums;
using Payments.Shared.ViewModels;

public class ApplicationViewModel : BaseViewModel
{
    public ApplicationStatus Status { get; set; }
    public string UserId { get; set; }
    public bool IsComplete { get; set; }

    public Guid PaymentId { get; set; }
    public PaymentViewModel Payment { get; set; }

    public Guid? BasicInformationId { get; set; }
    public BasicInformationViewModel BasicInformation { get; set; }

    public Guid? DocumentsId { get; set; }
    public ApplicationDocumentsViewModel Documents { get; set; }
}