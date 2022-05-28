namespace BasicInformations.Shared
{
   
    public class BasicInformationViewModel : BaseSettingViewModel
    {
        public string? IdNumber { get; set; }
        public string? StudentCode { get; set; }
        public DateTime BirthDate { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? FullAddress { get; set; }
        public string? Email { get; set; }
        public string? FatherName { get; set; }
        public string? FatherJob { get; set; }
        public string? FatherId { get; set; }
        public string? FatherPhone { get; set; }
        public string? GuardianName { get; set; }
        public string? GuardianId { get; set; }
        public string? GuardianRelationship { get; set; }
        public bool IsSpecialNeeds { get; set; }
        public bool IsFamilyOutside { get; set; }
        public double Degree { get; set; }
        public double PreviousGPA { get; set; }
        public Religion Religion { get; set; }
        public Level Level { get; set; }
        public Gender Gender { get; set; }
        public HousingType HousingType { get; set; }
        public ResidenceViewModel? Residence { get; set; }
        public Guid ResidenceId { get; set; }
        public FacultyViewModel? Faculty { get; set; }
        public Guid FacultyId { get; set; }

    }
}
