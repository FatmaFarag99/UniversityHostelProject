namespace Applications.Client.Components
{
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Authorization;
    using Payments.Shared.ViewModels;
    using System;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using UniversityHostel.SharedClient;

    public partial class PaymentForm
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationState { get; set; }

        [Parameter]
        public PaymentViewModel PaymentViewModel { get; set; }

        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;

        [Parameter]
        public EventCallback<PaymentViewModel> OnPaymentCompleted { get; set; }

        private bool isPaymentCompleted;

        private async Task HandleValidSubmit()
        {
            PaymentViewModel.UserId = await GetUserId();
            PaymentViewModel.TransactionId = Guid.NewGuid().ToString();
            PaymentViewModel = await _paymentHttpService.PostAsync("/api/payments", PaymentViewModel);
            string successMessage = "Payment Completed Successfuly";

            await OnPaymentCompleted.InvokeAsync(PaymentViewModel);
            isPaymentCompleted = true;

            _toastService.ShowSuccess(successMessage);

            StateHasChanged();
        }

        private async Task<string> GetUserId()
        {
            var authState = await AuthenticationState;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            }

            return null;
        }
    }
}