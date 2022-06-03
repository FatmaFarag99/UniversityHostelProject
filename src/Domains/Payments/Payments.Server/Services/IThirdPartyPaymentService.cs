namespace Payments.Server.Services
{
    using Payments.Server.Services.Models;
    using Payments.Shared.ViewModels;
    using System.Threading.Tasks;

    public interface IThirdPartyPaymentService
    {
        Task<ThirdPartyResponse> SendPaidRequest(string url, PaymentViewModel paymentViewModel);
    }
}