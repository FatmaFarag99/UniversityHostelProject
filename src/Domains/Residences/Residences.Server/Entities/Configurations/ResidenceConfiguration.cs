namespace Residences.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ResidenceConfiguration : BaseSettingConfiguration<Residence>
{
    public override void Configure(EntityTypeBuilder<Residence> builder)
    {
        base.Configure(builder);

        builder.ToTable("Residences");
    }
}
