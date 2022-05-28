namespace Account.Server.Entities.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(e => e.FullName).HasMaxLength(100);

        // Default Super Admin
        var superAdmin = new AppUser
        {
            Id = new Guid("5bf8f6b4-3e44-43f8-bf14-b5b1298f0bd7").ToString(),
            UserName = "Admin",
            NormalizedUserName = "Admin".ToUpper(),
            Email = "Admin@hostel.com",
            EmailConfirmed = true,
        };
        superAdmin.PasswordHash = new PasswordHasher<AppUser>().HashPassword(superAdmin, "123456");
        builder.HasData(superAdmin);

        // Default User
        var defaultUser = new AppUser
        {
            Id = new Guid("cca1c549-094b-4c45-a9c1-9960068e7f51").ToString(),
            UserName = "user",
            NormalizedUserName = "user".ToUpper(),
            Email = "user@hostel.com",
            EmailConfirmed = true,
        };

        defaultUser.PasswordHash = new PasswordHasher<AppUser>().HashPassword(defaultUser, "Hostel@123");
        builder.HasData(defaultUser);
    }
}
