namespace Payments.Server.Entities;

using Applications.Server.Entities;

public class Payment : BaseEntity
{
    public Guid? ApplicationId { get; set; }
    public Application? Application { get; set; }
    public string TransactionId { get; set; }
    public double PaidAmount { get; set; }

}