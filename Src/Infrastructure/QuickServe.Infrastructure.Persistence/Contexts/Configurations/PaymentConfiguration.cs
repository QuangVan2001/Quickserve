using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.Payments.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class PaymentConfiguration:  IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> entity)
    {
        entity.ToTable("Payment");



        entity.Property(e => e.Name)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.PaymentType)
            .HasMaxLength(255)
            .IsUnicode(false)
            .HasColumnName("Payment_type");
    }
}