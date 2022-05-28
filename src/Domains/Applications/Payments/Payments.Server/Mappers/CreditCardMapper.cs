namespace Faculties.Mappers;

public class CreditCardMapper : Profile
{
    public CreditCardMapper()
    {
        CreateMap<Payment, PaymentViewModel>().ReverseMap();
    }
}
