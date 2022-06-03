namespace Payments.Server.Services.Models
{
    using System.Collections.Generic;

    public class ThirdPartyResponse
    {
        public string TransactionId { get; set; }
        public double Amount { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }
    }
}
