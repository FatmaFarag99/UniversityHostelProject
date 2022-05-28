namespace Applications.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;
using Payments.Server.Entities;

public class ApplicationConfiguration : BaseConfiguration<Application>
{
    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        base.Configure(builder);

        builder.ToTable("Applications");

        builder.HasOne(a => a.Payment).WithOne().HasForeignKey<Payment>(p => p.ApplicationId);

        builder.Ignore(a => a.IsComplete);

        builder.HasMany(a => a.Documents).WithOne().HasForeignKey(d => d.ApplicationId);
    }
}
