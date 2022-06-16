namespace Applications.Shared.ViewModels;

using Applications.Shared.Enums;
using Payments.Shared.ViewModels;

public class ApplicationViewModel : BaseViewModel
{
    public ApplicationStatus Status { get; set; }
    public string UserId { get; set; }
    public bool IsComplete { get; set; }

    public ApplicationStep Step { get; set; }

    public Guid PaymentId { get; set; }
    public PaymentViewModel Payment { get; set; }

    public Guid? BasicInformationId { get; set; }
    public ApplicationBasicInformationViewModel BasicInformation { get; set; }

    public List<ApplicationDocumentViewModel> Documents { get; set; } = ((ApplicationDocumentType[])Enum.GetValues(typeof(ApplicationDocumentType))).Select(type => new ApplicationDocumentViewModel { Type = type }).ToList();
}