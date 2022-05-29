namespace Applications.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationConfiguration : BaseConfiguration<Application>
{
    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        base.Configure(builder);

        builder.ToTable("Applications");

        builder.Ignore(e => e.IsComplate);
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
    }
}