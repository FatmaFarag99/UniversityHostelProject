namespace BasicInformations.Server;

using Applications.Server.Entities;
using Faculties.Server.Entities;
using Residences.Server.Entities;

public class BasicInformation : BaseSettingEntity
{
    public Guid ApplicationId { get; set; }
    public Application Application { get; set; }
    public string IdNumber { get; set; }
    public string StudentCode { get; set; }
    public DateTime BirthDate { get; set; }
    public string PlaceOfBirth { get; set; }
    public string FullAddress { get; set; }
    public string Email { get; set; }
    public string FatherName { get; set; }
    public string FatherJob { get; set; }
    public string FatherId { get; set; }
    public string FatherPhone { get; set; }
    public string GuardianName { get; set; }
    public string GuardianId { get; set; }
    public string GuardianRelationship { get; set; }
    public bool IsSpecialNeeds { get; set; }
    public bool IsFamilyOutside { get; set; }
    public double Degree { get; set; }
    public double PreviousGPA { get; set; }
    public Religion Religion { get; set; }
    public Level Level { get; set; }
    public Gender Gender { get; set; }
    public HousingType HousingType { get; set; }
    public Guid ResidenceId { get; set; }
    public Residence Residence { get; set; }
    public Guid FacultyId { get; set; }
    public Faculty Faculty { get; set; }
}