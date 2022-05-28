namespace Payments.Server.Entities.Configurations;

using Microsoft.EntityFrameworkCore;

public class PaymentConfiguration : BaseConfiguration<Payment>
{
    public override void Configure(EntityTypeBuilder<Payment> builder)
    {
        base.Configure(builder);

        builder.ToTable("Payments");

        builder.Property(x => x.TransactionId).IsRequired();
    }
}
