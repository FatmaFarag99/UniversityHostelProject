namespace Documents.Shared.Validations;

public class DocumentValidator : BaseValidator<DocumentViewModel>
{
    public DocumentValidator() : base()
    {
        RuleFor(d => d.Content).NotEmpty();
    }
}