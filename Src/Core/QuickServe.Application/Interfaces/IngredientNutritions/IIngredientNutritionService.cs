using QuickServe.Application.DTOs.IngredientNutrions.Request;
using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request;
using QuickServe.Application.DTOs.ProductTemplates.Request;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.IngredientNutritions
{
    public interface IIngredientNutritionService
    {
        Task<BaseResult> CreateIngredientNutritionAsync(CreateIngredientNutritionRequest request);
        Task<BaseResult> UpdateIngredientNutritionAsync(CreateIngredientNutritionRequest request);
        Task<BaseResult> GetByIngredientIdAsync(long ingredientId);
        Task<BaseResult> DeleteIngredientNutritionAsync(long ingredientId);
    }
}
