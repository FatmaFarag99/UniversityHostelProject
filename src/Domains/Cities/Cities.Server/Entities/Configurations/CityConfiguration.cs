namespace Cities.Server.Entities.Configurations;

public class CityConfiguration : BaseSettingConfiguration<City>
{
    public override void Configure(EntityTypeBuilder<City> builder) => base.Configure(builder);
}
