namespace Account.Shared.Validations;

public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordViewModel>
{
    public ForgotPasswordValidator()
    {
        RuleFor(e => e.Email).NotEmpty().EmailAddress();
    }
}