namespace Payments.Server.Services
{
    using Newtonsoft.Json;
    using Payments.Server.Services.Models;
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class ThirdPartyPaymentService : IThirdPartyPaymentService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<ThirdPartyResponse> SendPaidRequest(string url, PaymentViewModel paymentViewModel)
        {
            ThirdPartyResponse thirdPartyResponse = new ThirdPartyResponse();
            try
            {
                _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("PostmanRuntime/7.19.0");

                string payload = JsonConvert.SerializeObject(paymentViewModel);
                HttpContent contentToPost = new StringContent(payload, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync(url, contentToPost);

                string result = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    thirdPartyResponse = JsonConvert.DeserializeObject<ThirdPartyResponse>(result);
                    thirdPartyResponse.IsSuccess = true;
                }
                return thirdPartyResponse;
            }
            catch (Exception exception)
            {
                thirdPartyResponse.Errors.Add(exception.Message);
            }
            return thirdPartyResponse;
        }
    }
}
