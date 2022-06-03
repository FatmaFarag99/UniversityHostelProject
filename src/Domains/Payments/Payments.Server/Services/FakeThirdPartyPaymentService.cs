namespace Payments.Server.Services
{
    using Payments.Server.Services.Models;
    using System;
    using System.Threading.Tasks;

    public class FakeThirdPartyPaymentService : IThirdPartyPaymentService
    {
        public async Task<ThirdPartyResponse> SendPaidRequest(string url, PaymentViewModel paymentViewModel)
        {
            return await Task.FromResult<ThirdPartyResponse>(new ThirdPartyResponse
            {
                TransactionId = Guid.NewGuid().ToString(),
                Amount = 200,
                IsSuccess = true
            });
        }
    }
}
