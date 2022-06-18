namespace ApplicationSettings.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationStageConfiguration : BaseConfiguration<ApplicationStage>
{
    public override void Configure(EntityTypeBuilder<ApplicationStage> builder)
    {
        base.Configure(builder);

        builder.ToTable("ApplicationStages");

        builder.Property(x => x.EndTime).IsRequired();

        ApplicationStage applicationSetting = new ApplicationStage
        {
            Id = Guid.Parse("e9bb6388-d68d-4346-9981-3a0e8150498f"),
            StageStatus = StageStatus.Opened,
            EndTime = DateTime.Now.AddDays(7),
        };

        builder.HasData(applicationSetting);
    }
}