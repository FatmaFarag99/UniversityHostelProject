namespace Payments.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");


        builder.Property(x => x.TransactionId).IsRequired();
        builder.HasIndex(x => x.TransactionId).IsUnique();

        builder.HasOne(e => e.User).WithMany().HasForeignKey(e => e.UserId).OnDelete(DeleteBehavior.Cascade);
        base.Configure(builder);
    }
}
