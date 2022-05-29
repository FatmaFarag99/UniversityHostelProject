namespace Documents.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class DocumentConfiguration : BaseConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        base.Configure(builder);

        builder.ToTable("Documents");

        builder.HasOne(e => e.Application).WithMany().HasForeignKey(e => e.ApplicationId).OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(e => e.Attachments).WithOne().HasForeignKey(e => e.DocumentId).OnDelete(DeleteBehavior.Cascade);
    }
}
