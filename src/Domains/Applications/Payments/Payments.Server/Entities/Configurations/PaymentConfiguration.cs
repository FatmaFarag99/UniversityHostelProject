namespace Payments.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable("Payments");


        builder.HasOne(e => e.Application).WithMany().HasForeignKey(e => e.ApplicationId).OnDelete(DeleteBehavior.SetNull);
        builder.Property(x => x.TransactionId).IsRequired();
        base.Configure(builder);
    }
}
