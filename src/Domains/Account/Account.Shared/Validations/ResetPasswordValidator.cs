namespace Account.Shared.Validations;

public class ResetPasswordValidator : AbstractValidator<ResetPasswordViewModel>
{
    public ResetPasswordValidator()
    {
        RuleFor(e => e.Email).NotEmpty().EmailAddress();
        RuleFor(e => e.Password).NotEmpty();
        RuleFor(e => e.ConfirmPassword).NotEmpty();
        RuleFor(e => e.Code).NotEmpty();
    }
}