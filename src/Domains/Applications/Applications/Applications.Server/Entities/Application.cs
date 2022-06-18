namespace Applications.Server.Entities;

using Account.Server.Entities;
using Applications.Shared.Enums;
using ApplicationSettings.Server.Entities;
using Payments.Server.Entities;

public class Application : BaseEntity
{
    public string UserId { get; set; }
    public AppUser User { get; set; }
    public ApplicationStatus Status { get; set; }
    public Guid? ApplicationStageId { get; set; }
    public ApplicationStage ApplicationStage { get; set; }

    //public bool IsComplete => DocumentsId != default;

    //public bool IsComplate => Step.Equals(ApplicationStep.Documents);

    //public ApplicationStep Step { get; set; }

    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }

    public Guid? BasicInformationId { get; set; }
    public ApplicationBasicInformation BasicInformation { get; set; }

    public List<ApplicationDocument> Documents { get; set; }
}