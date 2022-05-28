namespace Payments.Server.Entities
{
    public class Payment : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public string TransactionId { get; set; }
    }
}