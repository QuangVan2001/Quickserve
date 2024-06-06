using QuickServe.Domain.IngredientTypeTemplateSteps.Entities;
using QuickServe.Domain.ProductTemplates.Entities;
using QuickServe.Domain.TemplateSteps.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickServe.Domain.TemplateSteps.Dtos
{
    public class TemplateStepDTO
    {
        public TemplateStepDTO() { }
        public TemplateStepDTO(TemplateStep templateStep)
        {
            Id = templateStep.Id;
            Name = templateStep.Name;
            Status = templateStep.Status;
            Created = templateStep.Created;
            CreatedBy = templateStep.CreatedBy;
            LastModified = templateStep.LastModified ?? null;  // Xử lý giá trị NULL
            LastModifiedBy = templateStep.LastModifiedBy ?? null;
            ProductTemplateId = templateStep.ProductTemplateId;
        }

        public long Id { get; set; }
        public long ProductTemplateId { get; set; }
        public string Name { get; set; } = null!;
        public int Status { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime Created { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public virtual ProductTemplate ProductTemplate { get; set; } = null!;
    }
}
