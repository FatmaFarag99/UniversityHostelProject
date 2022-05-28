namespace Applications.Client.Components;

public partial class ApplicationFormViewComponent
{
    [Parameter]
    public Guid ApplicationId { get; set; }
    [Parameter]
    public string SystemFeatureTypeParameter { get; set; }

    private SystemFeatureType systemFeatureType = SystemFeatureType.Add;
    private ApplicationViewModel applicationViewModel = new ApplicationViewModel()
    {
        Payment = new PaymentViewModel(),
        CreditCard = new CreditCardViewModel()
    };

    protected override async Task OnInitializedAsync()
    {
        systemFeatureType = (SystemFeatureType)Enum.Parse(typeof(SystemFeatureType), SystemFeatureTypeParameter, true);

        if (systemFeatureType.Equals(SystemFeatureType.Add))
            return;

        applicationViewModel = await _applicationHttpService.GetByIdAsync($"/api/applications/{ApplicationId.ToString()}");
    }
}
