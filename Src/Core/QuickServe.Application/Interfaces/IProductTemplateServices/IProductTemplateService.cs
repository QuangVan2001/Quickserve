using QuickServe.Application.DTOs.Ingredients.Request;
using QuickServe.Application.DTOs.ProductTemplates;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.IProductTemplateServices
{
    public interface IProductTemplateService
    {
        Task<BaseResult> CreateProductTemplateAsync(CreateProductTemplateRequest request);
        Task<BaseResult> UpdateProductTemplateImageAsync(long id, UpdateProductTemplateImageRequest request);
    }
}
