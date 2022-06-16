namespace Applications.Shared.Validations;

using FluentValidation;

public class ApplicationValidator : BaseValidator<ApplicationViewModel>
{
    public ApplicationValidator() : base()
    {
        RuleFor(a => a.UserId).NotEmpty();
        RuleFor(a => a.BasicInformation).SetValidator(a => new ApplicationBasicInformationValidator());
        RuleFor(a => a.Documents).NotEmpty();
    }
}