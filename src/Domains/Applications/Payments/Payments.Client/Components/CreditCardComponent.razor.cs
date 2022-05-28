namespace Payments.Client.Components
{
    public partial class CreditCardComponent
    {
        [Parameter]
        public CreditCardViewModel CreditCardViewModel { get; set; } = new CreditCardViewModel();
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;
    }
}
