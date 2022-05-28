namespace Account.Server.Entities.Configurations;

public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
    {
        IdentityUserRole<string> admin = new IdentityUserRole<string>
        {
            RoleId = "da80425e-f97f-469b-98ef-bd481b034777",
            UserId = "5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7"
        };

        IdentityUserRole<string> user = new IdentityUserRole<string>
        {
            RoleId = "e9bb6388-d68d-4346-9981-3a0e8150498f",
            UserId = "cca1c549-094b-4c45-a9c1-9960068e7f51"
        };

        builder.HasData(admin, user);
    }
}
