namespace Payments.Shared.ViewModels
{
    public class CreditCardViewModel : BaseViewModel
    {
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int CVC { get; set; }
    }
}
