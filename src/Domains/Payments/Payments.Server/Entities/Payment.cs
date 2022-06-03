namespace Payments.Server.Entities;

using Account.Server.Entities;

public class Payment : BaseEntity
{
    public string TransactionId { get; set; }
    public double PaidAmount { get; set; }
    public string UserId { get; set; }
    public AppUser User { get; set; }
}