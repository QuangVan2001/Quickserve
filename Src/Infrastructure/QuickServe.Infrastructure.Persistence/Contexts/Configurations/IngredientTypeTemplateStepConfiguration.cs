using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickServe.Domain.IngredientTypeTemplateSteps.Entities;

namespace QuickServe.Infrastructure.Persistence.Contexts.Configurations;

public class IngredientTypeTemplateStepConfiguration : IEntityTypeConfiguration<IngredientTypeTemplateStep>
{
    public void Configure(EntityTypeBuilder<IngredientTypeTemplateStep> entity)
    {
        entity.HasKey(e => new { e.IngredientTypeId, e.TemplateStepId })
            .HasName("PK__Ingredie__D37B8AD7132C9711");

        entity.ToTable("IngredientType_TemplateStep");

        entity.Property(e => e.IngredientTypeId).HasColumnName("IngredientType_Id");

        entity.Property(e => e.TemplateStepId).HasColumnName("TemplateStep_Id");

        entity.Property(e => e.QuantityMax).HasColumnName("Quantity_Max").IsRequired();

        entity.Property(e => e.QuantityMin).HasColumnName("Quantity_Min").IsRequired();

        entity.HasOne(d => d.IngredientType)
            .WithMany(p => p.IngredientTypeTemplateSteps)
            .HasForeignKey(d => d.IngredientTypeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("IngredientType_templateStep_ingredienttype_id_foreign");

        entity.HasOne(d => d.TemplateStep)
            .WithMany(p => p.IngredientTypeTemplateSteps)
            .HasForeignKey(d => d.TemplateStepId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("ingredienttype_templatestep_templatestep_id_foreign");
    }
}