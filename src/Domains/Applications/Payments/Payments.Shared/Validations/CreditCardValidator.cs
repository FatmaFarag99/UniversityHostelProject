namespace Payments.Shared.Validations;

public class CreditCardValidator : BaseValidator<CreditCardViewModel>
{
    public CreditCardValidator() : base()
    {
        RuleFor(e => e.CVC).NotEmpty();
        RuleFor(e => e.Number).NotEmpty().MaximumLength(16).MinimumLength(16);
        RuleFor(e => e.ExpirationDate).NotEmpty().GreaterThan(DateTime.Now);
    }
}
