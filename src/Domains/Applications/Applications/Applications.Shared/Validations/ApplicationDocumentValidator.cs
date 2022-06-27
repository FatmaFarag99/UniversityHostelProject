namespace Applications.Shared.Validations;

using Documents.Shared.Validations;

public class ApplicationDocumentValidator : BaseValidator<ApplicationDocumentViewModel>
{
    public ApplicationDocumentValidator() : base()
    {
        RuleFor(ad => ad.Document).SetValidator(document => new DocumentValidator());
    }
}