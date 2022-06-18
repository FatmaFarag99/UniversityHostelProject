namespace Applications.Shared.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationGridViewModel : BaseViewModel
    {
        public string StudentName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string FullAddress { get; set; }
        public string FatherJob { get; set; }
        public string GuardianName { get; set; }
        public string GuardianRelationship { get; set; }
        public bool IsSpecialNeeds { get; set; }
        public bool IsFamilyOutside { get; set; }
        public double Degree { get; set; }
        public double PreviousGPA { get; set; }
        public Level Level { get; set; }
        public Gender Gender { get; set; }
        public HousingType HousingType { get; set; }
        public string ResidenceName { get; set; }
        public string FacultyName { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}
