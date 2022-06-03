namespace Payments.Client.Components
{
    public partial class CreditCardComponent
    {
        [Parameter]
        public SystemFeatureType SystemFeatureType { get; set; } = SystemFeatureType.Add;
    }
}
