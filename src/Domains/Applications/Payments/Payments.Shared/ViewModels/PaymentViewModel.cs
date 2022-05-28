namespace Payments.Shared.ViewModels;

public class PaymentViewModel : BaseViewModel
{
    public Guid ApplicationId { get; set; }
    public string TransactionId { get; set; }
}
