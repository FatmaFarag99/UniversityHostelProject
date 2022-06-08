namespace Applications.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class ApplicationDocumentConfiguration : BaseConfiguration<ApplicationDocument>
{
    public override void Configure(EntityTypeBuilder<ApplicationDocument> builder)
    {
        base.Configure(builder);

        builder.ToTable("ApplicationDocument");

        builder.HasOne(d => d.Document).WithOne().HasForeignKey<ApplicationDocument>(d => d.DocumentId).OnDelete(DeleteBehavior.Cascade);
    }
}