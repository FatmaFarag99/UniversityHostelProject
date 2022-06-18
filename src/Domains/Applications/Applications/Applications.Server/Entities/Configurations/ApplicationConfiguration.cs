namespace Applications.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;
using Payments.Server.Entities;

public class ApplicationConfiguration : BaseConfiguration<Application>
{
    public override void Configure(EntityTypeBuilder<Application> builder)
    {
        base.Configure(builder);

        builder.ToTable("Applications");

        //builder.Ignore(e => e.IsComplete);
        
        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(a => a.Payment).WithOne().HasForeignKey<Application>(b => b.PaymentId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(a => a.BasicInformation).WithOne().HasForeignKey<ApplicationBasicInformation>(b => b.ApplicationId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(a => a.ApplicationStage).WithMany().HasForeignKey(b => b.ApplicationStageId).OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(a => a.Documents).WithOne().HasForeignKey(d => d.ApplicationId).OnDelete(DeleteBehavior.Cascade);
    }
}