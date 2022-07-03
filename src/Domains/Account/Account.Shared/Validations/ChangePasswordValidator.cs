namespace Account.Shared.Validations;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordViewModel>
{
    public ChangePasswordValidator()
    {
        RuleFor(e => e.OldPassword).NotEmpty();
        RuleFor(e => e.NewPassword).NotEmpty();
        RuleFor(e => e.ConfirmNewPassword).NotEmpty();
    }
}