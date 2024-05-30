using QuickServe.Application.DTOs.Ingredients.Request;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.IngredientInterfaces
{
    public interface IIngredientService
    {
        Task<BaseResult> CreateIngredientAsync(CreateIngredientRequest request);
        Task<BaseResult> UpdateIngredientImageAsync(long id, UpdateIngredientImageRequest request);
    }
}
