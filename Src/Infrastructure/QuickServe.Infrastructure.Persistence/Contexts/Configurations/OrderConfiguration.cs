using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.Orders.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class OrderConfiguration :  IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> entity)
    {
        
        entity.ToTable("Orders");

        entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

        entity.Property(e => e.Created).HasColumnType("date");

        entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_id");

        entity.Property(e => e.Status)
            .HasMaxLength(255)
            .IsUnicode(false);

        entity.Property(e => e.StoreId).HasColumnName("Store_id");



        entity.HasOne(d => d.PaymentMethod)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.PaymentMethodId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("order_payment_method_id_foreign");

        entity.HasOne(d => d.Store)
            .WithMany(p => p.Orders)
            .HasForeignKey(d => d.StoreId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("order_store_id_foreign");
    }
}