namespace Faculties.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class FacultyConfiguration : BaseSettingConfiguration<Faculty>
{
    public override void Configure(EntityTypeBuilder<Faculty> builder)
    {
        base.Configure(builder);

        builder.ToTable("Faculties");
    }
}
