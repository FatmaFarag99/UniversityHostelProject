namespace ApplicationSettings.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationSettingConfiguration : BaseConfiguration<ApplicationSetting>
{
    public override void Configure(EntityTypeBuilder<ApplicationSetting> builder)
    {
        base.Configure(builder);

        builder.ToTable("ApplicationSettings");

        builder.Property(x => x.PhaseEndTime).IsRequired();

        ApplicationSetting applicationSetting = new()
        {
            Id = Guid.Parse("e9bb6388-d68d-4346-9981-3a0e8150498f"),
            IsRegistrationEnabled = true,
            PhaseEndTime = DateTime.Now.AddDays(7),
        };

        builder.HasData(applicationSetting);
    }
}