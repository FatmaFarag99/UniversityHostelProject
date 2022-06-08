namespace Documents.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class DocumentConfiguration : BaseConfiguration<Document>
{
    public override void Configure(EntityTypeBuilder<Document> builder)
    {
        base.Configure(builder);

        builder.ToTable("Documents");
    }
}
