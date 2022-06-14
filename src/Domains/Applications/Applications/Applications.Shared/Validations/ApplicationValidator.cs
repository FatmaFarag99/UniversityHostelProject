namespace Applications.Shared.Validations;

using FluentValidation;

public class ApplicationValidator : BaseValidator<ApplicationViewModel>
{
    public ApplicationValidator() : base()
    {
        RuleFor(e => e.UserId).NotEmpty();
        RuleFor(a => a.BasicInformation).SetValidator(a => new BasicInformationValidator());
    }
}
