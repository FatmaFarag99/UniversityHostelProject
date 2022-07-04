namespace ApplicationSettings.Shared.Validations;

using FluentValidation;

public class ApplicationStageValidator : BaseValidator<ApplicationStageViewModel>
{
    public ApplicationStageValidator() : base()
    {
        RuleFor(x => x.EndTime).NotEmpty().GreaterThanOrEqualTo(DateTime.Today);
    }
}