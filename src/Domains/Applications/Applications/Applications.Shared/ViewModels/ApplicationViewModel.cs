namespace Applications.Shared.ViewModels;

using BasicInformations.Shared;

public class ApplicationViewModel : BaseViewModel
{
    public Guid PaymentId { get; set; }
    public PaymentViewModel Payment { get; set; }

    public Guid? BasicInformationId { get; set; }
    public BasicInformationViewModel BasicInformation { get; set; }

    public CreditCardViewModel CreditCard { get; set; }

    //public bool IsComplete { get; set; }
    public bool IsComplete => BasicInformationId != null;
}
