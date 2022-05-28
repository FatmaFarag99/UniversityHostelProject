namespace Applications.Server.Entities;

using Applications.Shared.Enums;
using BasicInformations.Server;
using Documents.Server.Entities;
using Payments.Server.Entities;

public class Application : BaseEntity
{
    public Guid PaymentId { get; set; }
    public Payment Payment { get; set; }

    public Guid? BasicInformationId { get; set; }
    public BasicInformation BasicInformation { get; set; }

    //TODO: Documents
    public List<Document> Documents { get; set; }


    public ApplicationStatus Status { get; set; }

    public bool IsComplete => BasicInformationId != null;
}
