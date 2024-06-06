using QuickServe.Domain.TemplateSteps.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Response
{
    public class TemplateResponse
    {
        public long TemplateStepId {  get; set; }
        public string Name { get; set; }

        public List<IngredientTypeResponse> IngredientTypes { get; set; }


        public TemplateResponse() { }
        public TemplateResponse(TemplateStep templateStep)
        {
            TemplateStepId = templateStep.Id;
            Name = templateStep.Name;
        }
    }
}
