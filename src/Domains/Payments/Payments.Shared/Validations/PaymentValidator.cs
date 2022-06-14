namespace Payments.Shared.Validations;

using System.Text.RegularExpressions;

public class PaymentValidator : BaseValidator<PaymentViewModel>
{
    public PaymentValidator() : base()
    {
        RuleFor(x => x.CardNumber).NotEmpty().CreditCard();
        RuleFor(x => x.CVV).NotEmpty().Length(3);
        RuleFor(x => x.ExpiryDate).NotEmpty().Matches(new Regex("(?:0[1-9]|1[0-2])/[0-9]{2}"));
        //RuleFor(x => x.ExpiryYear).NotEmpty().Length(4);
        //RuleFor(x => x.ExpiryMonth).NotEqual(0).LessThanOrEqualTo(12);
    }
}