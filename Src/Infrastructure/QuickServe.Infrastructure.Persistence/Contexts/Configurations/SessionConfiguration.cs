using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.Ingredients.Entities;
using QuickServe.Domain.Sessions.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> entity)
    {
        entity.ToTable("Session");

        entity.Property(e => e.EndTime).HasColumnName("End_Time");

        entity.Property(e => e.IngredientId).HasColumnName("Ingredient_Id");

      

        entity.Property(e => e.Name)
            .HasMaxLength(40)
            .IsUnicode(false);

        entity.Property(e => e.OrderId).HasColumnName("Order_Id");

        entity.Property(e => e.StartTime).HasColumnName("Start_Time").IsRequired();

        entity.Property(e => e.StoreId).HasColumnName("Store_Id").IsRequired();

        entity.HasMany(d => d.Ingredients)
            .WithMany(p => p.Sessions)
            .UsingEntity<Dictionary<string, object>>(
                "IngredientSession",
                l => l.HasOne<Ingredient>().WithMany().HasForeignKey("IngredientId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Ingredien__Ingre__60A75C0F"),
                r => r.HasOne<Session>().WithMany().HasForeignKey("SessionId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Ingredien__Sessi__619B8048"),
                j =>
                {
                    j.HasKey("SessionId", "IngredientId").HasName("PK__Ingredie__455B9AFE7F7A4C49");

                    j.ToTable("IngredientSession");

                    j.IndexerProperty<long>("SessionId").HasColumnName("Session_Id");

                    j.IndexerProperty<long>("IngredientId").HasColumnName("Ingredient_Id");
                });
    }
}