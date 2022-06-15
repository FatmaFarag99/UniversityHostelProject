namespace Payments.Shared.Validations;

using System.Text.RegularExpressions;

public class PaymentValidator : BaseValidator<PaymentViewModel>
{
    public PaymentValidator() : base()
    {
        RuleFor(x => x.CardNumber).NotEmpty().CreditCard();
        RuleFor(x => x.CVV).NotEmpty().Length(3);
        RuleFor(x => x.ExpiryMonth).NotEmpty().Matches(new Regex("(?:0[1-9]|1[0-2])"));
        RuleFor(x => x.ExpiryYear).NotEmpty().Matches(new Regex("[0-9]{2}"));
    }
}