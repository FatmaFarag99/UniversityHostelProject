namespace Payments.Shared.ViewModels;

public class PaymentViewModel : BaseViewModel
{
    public string CardNumber { get; set; }
    public string CVV { get; set; }
    public string ExpiryDate { get; set; }
    public int ExpiryMonth { get; set; }
    public string ExpiryYear { get; set; }
}
