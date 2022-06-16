namespace ApplicationSettings.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationSettingConfiguration : BaseConfiguration<ApplicationSetting>
{
    public override void Configure(EntityTypeBuilder<ApplicationSetting> builder)
    {
        base.Configure(builder);

        builder.ToTable("ApplicationSettings");

        builder.Property(x => x.PhaseEndTime).IsRequired();
    }
}
