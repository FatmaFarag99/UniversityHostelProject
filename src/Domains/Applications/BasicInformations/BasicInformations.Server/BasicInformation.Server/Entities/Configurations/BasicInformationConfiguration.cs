namespace BasicInformations.Server;

using Microsoft.EntityFrameworkCore;

public class BasicInformationConfiguration : BaseSettingConfiguration<BasicInformation>
{
    public override void Configure(EntityTypeBuilder<BasicInformation> builder)
    {
        base.Configure(builder);

        builder.ToTable("BasicInformations");

        builder.HasOne(x => x.Residence).WithMany().HasForeignKey(x => x.ResidenceId);
        builder.HasOne(x => x.Faculty).WithMany().HasForeignKey(x => x.FacultyId);

        builder.Property(x => x.HousingType).IsRequired();
        builder.Property(x => x.FatherJob).IsRequired();
        builder.Property(x => x.FatherId).IsRequired();
        builder.Property(x => x.StudentCode).IsRequired();
        builder.Property(x => x.BirthDate).IsRequired();
        builder.Property(x => x.Degree).IsRequired();
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.FacultyId).IsRequired();
        builder.Property(x => x.FatherName).IsRequired();
        builder.Property(x => x.FatherPhone).IsRequired();
        builder.Property(x => x.FullAddress).IsRequired();
        builder.Property(x => x.Gender).IsRequired();
        builder.Property(x => x.GuardianId).IsRequired();
        builder.Property(x => x.GuardianName).IsRequired();
        builder.Property(x => x.GuardianRelationship).IsRequired();
        builder.Property(x => x.PreviousGPA).IsRequired();
        builder.Property(x => x.IdNumber).IsRequired();
        builder.Property(x => x.IsFamilyOutside).IsRequired();
        builder.Property(x => x.IsSpecialNeeds).IsRequired();
        builder.Property(x => x.Level).IsRequired();
        builder.Property(x => x.PlaceOfBirth).IsRequired();
        builder.Property(x => x.ResidenceId).IsRequired();
    }
}
