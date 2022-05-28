namespace Payments.Shared.Validations;

public class PaymentValidator : BaseValidator<PaymentViewModel>
{
    public PaymentValidator() : base()
    {
        RuleFor(x => x.TransactionId).NotEmpty();
    }
}