namespace Account.Server.Entities.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(new IdentityRole
        {
            Id = "da80425e-f97f-469b-98ef-bd481b034777",
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
        new IdentityRole
        {
            Id = "e9bb6388-d68d-4346-9981-3a0e8150498f",
            Name = "User",
            NormalizedName = "USER"
        });
    }
}
