namespace Payments.Shared.Validations;

public class PaymentValidator : BaseValidator<PaymentViewModel>
{
    public PaymentValidator() : base()
    {
        RuleFor(x => x.CardNumber).NotEmpty().Length(16);
        RuleFor(x => x.CVV).NotEmpty().Length(3);
        RuleFor(x => x.ExpiryYear).NotEmpty().Length(4);
        RuleFor(x => x.ExpiryMonth).NotEqual(0).LessThanOrEqualTo(12);
    }
}