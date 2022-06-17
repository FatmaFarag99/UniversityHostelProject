namespace ApplicationSettings.Shared.Validations;

using FluentValidation;

public class ApplicationSettingValidator : BaseValidator<ApplicationSettingViewModel>
{
    public ApplicationSettingValidator() : base()
    {
        RuleFor(x => x.PhaseEndTime).NotEmpty().GreaterThanOrEqualTo(DateTime.Now);
    }
}
