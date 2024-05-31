using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request;
using QuickServe.Application.DTOs.ProductTemplates.Request;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.IngredientTypeTemplateSteps
{
    public interface IIngredientTypeTemplateStepService
    {
        Task<BaseResult> CreateTempalte(CreateTemplateRequest request);
        Task<BaseResult> UpdateTempalte(CreateTemplateRequest request);
        Task<BaseResult> GetAll(GetAllTemplateRequest request);
        Task<BaseResult> GetById(GetTemplateByIdRequest request);
        Task<BaseResult> UpdateTemplateStatus(UpdateTemplateStatusRequest request);
        Task<BaseResult> DeleteTemplate(DeleteTemplateRequest request);
    }
}
