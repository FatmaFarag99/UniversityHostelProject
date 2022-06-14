namespace Applications.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationDocumentsConfiguration : BaseConfiguration<ApplicationDocuments>
{
    public override void Configure(EntityTypeBuilder<ApplicationDocuments> builder)
    {
        base.Configure(builder);

        builder.ToTable("ApplicationDocuments");

        builder.HasOne(e => e.Document1).WithOne().HasForeignKey<ApplicationDocument>(d => d.ApplicationId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Document2).WithOne().HasForeignKey<ApplicationDocument>(d => d.ApplicationId).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(e => e.Document3).WithOne().HasForeignKey<ApplicationDocument>(d => d.ApplicationId).OnDelete(DeleteBehavior.Cascade);
    }
}