namespace Applications.Shared.Validations
{

    public class ApplicationBasicInformationValidator : BaseSettingValidator<ApplicationBasicInformationViewModel>
    {
        public ApplicationBasicInformationValidator() : base()
        {
            //RuleFor(e => e.ApplicationId).NotEmpty();
            RuleFor(e => e.IdNumber).NotEmpty().MaximumLength(14).MinimumLength(14);
            RuleFor(e => e.GuardianId).NotEmpty();
            RuleFor(e => e.GuardianName).NotEmpty();
            RuleFor(e => e.GuardianRelationship).NotEmpty();
            RuleFor(e => e.FullAddress).NotEmpty();
            RuleFor(e => e.Email).NotEmpty();
            RuleFor(e => e.FatherName).NotEmpty();
            RuleFor(e => e.FatherJob).NotEmpty();
            RuleFor(e => e.FatherPhone).NotEmpty();
            RuleFor(e => e.FatherId).NotEmpty();
            RuleFor(e => e.BirthDate).NotEmpty();
            RuleFor(e => e.Degree).NotEmpty();
            RuleFor(e => e.Gender).NotEmpty();
            RuleFor(e => e.Level).NotEmpty();
            RuleFor(e => e.HousingType).NotEmpty();
            RuleFor(e => e.PreviousGPA).NotEmpty();
            RuleFor(e => e.PlaceOfBirth).NotEmpty();
            RuleFor(e => e.StudentCode).NotEmpty();
            RuleFor(e => e.ResidenceId).NotEmpty();
            RuleFor(e => e.FacultyId).NotEmpty();
        }
    }
}
