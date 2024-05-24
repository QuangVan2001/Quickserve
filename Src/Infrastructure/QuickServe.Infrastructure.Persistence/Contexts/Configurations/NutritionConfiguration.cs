using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.Nutritions.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class NutritionConfiguration  : IEntityTypeConfiguration<Nutrition>

{
    public void Configure(EntityTypeBuilder<Nutrition> entity)
    {
        entity.ToTable("Nutrition");

        entity.HasIndex(e => e.IngredientId, "UQ__Nutritio__C90398E29135F4A4")
            .IsUnique();

        entity.Property(e => e.CreatedBy).HasMaxLength(40);

        entity.Property(e => e.Created).HasColumnType("date");

      

        entity.Property(e => e.HealthValue).HasMaxLength(100);

        entity.Property(e => e.ImageUrl).HasMaxLength(255);
        entity.Property(e => e.Description).HasMaxLength(100);

        entity.Property(e => e.IngredientId).HasColumnName("Ingredient_id");

    

        entity.Property(e => e.LastModifiedBy).HasMaxLength(40);

        entity.Property(e => e.LastModified).HasColumnType("date");

        entity.Property(e => e.Name).HasMaxLength(40);

        entity.Property(e => e.Nutrition1)
            .HasMaxLength(255)
            .HasColumnName("Nutrition");

        entity.Property(e => e.Vitamin).HasMaxLength(40);

        entity.HasOne(d => d.Ingredient)
            .WithOne(p => p.Nutrition)
            .HasForeignKey<Nutrition>(d => d.IngredientId)
            .HasConstraintName("FK__Nutrition__Nutri__03F0984C");
    }
}