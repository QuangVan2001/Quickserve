using QuickServe.Application.DTOs.ProductTemplates.Request;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.IngredientTypeTemplateSteps;
using QuickServe.Application.Wrappers;
using QuickServe.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuickServe.Application.Helpers;
using QuickServe.Domain.IngredientTypeTemplateSteps.Entities;
using QuickServe.Application.DTOs.ProductTemplates.Response;
using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Response;
using QuickServe.Application.DTOs.IngredientTypeTemplateSteps.Request;
using QuickServe.Application.Utils.Enums;
using System.ComponentModel.Design;

namespace QuickServe.Infrastructure.Persistence.Services
{
    public class IngredientTypeTemplateStepService : IIngredientTypeTemplateStepService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITranslator _translator;
        private readonly IUnitOfWork _unitOfWork;

        public IngredientTypeTemplateStepService(ApplicationDbContext context, ITranslator translator, IUnitOfWork unitOfWork)
        {
            _context = context;
            _translator = translator;
            _unitOfWork = unitOfWork;
        }
        public async Task<BaseResult> CreateTempalte(CreateTemplateRequest request)
        {
            try
            {
                var templateStep = await _context.TemplateSteps.FirstOrDefaultAsync(c => c.Id == request.TemplateStepId);

                if (templateStep == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.TemplateStepMessages.TemplateStep_not_found_with_id(request.TemplateStepId)), nameof(request.TemplateStepId)));
                }
                foreach(var ingreType in request.IngredientType)
                {
                    var ingredientType = await _context.IngredientTypes.FirstOrDefaultAsync(i => i.Id == ingreType.IngredientTypeId);
                    if (ingredientType == null)
                    {
                        return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.IngredientTypeMessages.IngredientType_not_Found_with_id(ingreType.IngredientTypeId)), nameof(ingreType.IngredientTypeId)));
                    }
                }
               
                foreach (var newIngredientType in request.IngredientType)
                {
                    var ingredientProduct = new IngredientTypeTemplateStep
                    {
                        TemplateStepId = request.TemplateStepId,
                        IngredientTypeId = newIngredientType.IngredientTypeId,
                        QuantityMax = newIngredientType.QuantityMax,
                        QuantityMin = newIngredientType.QuantityMin,
                    };
                    await _context.IngredientTypeTemplateSteps.AddAsync(ingredientProduct);
                }
                templateStep.Update((int)TemplateStepStatus.Active);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResult();
            }
            catch (Exception ex)
            {
                return new BaseResult($"An error occurred while creating the template: {ex.Message}");
            }
    
        }

        public async Task<BaseResult> DeleteTemplate(DeleteTemplateRequest request)
        {
            try
            {
                var templateStep = await _context.TemplateSteps.Include(c=> c.ProductTemplate).FirstOrDefaultAsync(c => c.Id == request.TemplateStepId);
                if (templateStep == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.TemplateStepMessages.TemplateStep_not_found_with_id(request.TemplateStepId)), nameof(request.TemplateStepId)));
                }
                var existsTemplate = await _context.IngredientTypeTemplateSteps
                    .Where(c => c.TemplateStepId == request.TemplateStepId).ToListAsync();
                if (existsTemplate.Any())
                {
                    _context.IngredientTypeTemplateSteps.RemoveRange(existsTemplate);
                }
                templateStep.Status =(int) TemplateStepStatus.Inactive;
                templateStep.ProductTemplate.Status = (int)ProductTemplateStatus.Inactive;
                await _unitOfWork.SaveChangesAsync();
                return new BaseResult();
            }
            catch (Exception ex) {
                return new BaseResult($"An error occurred while delete the template: {ex.Message}");
            }
        }

        public async Task<BaseResult> GetAll(GetAllTemplateRequest request)
        {
            try
            {
                var productTemplate = await _context.ProductTemplates
                    .Include(c=> c.TemplateSteps).ThenInclude(c=> c.IngredientTypeTemplateSteps)
                    .ThenInclude(c=> c.IngredientType)
                    .FirstOrDefaultAsync(c => c.Id == request.ProductTemplateId);
                
                if (productTemplate == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.ProductTemplateMessages.ProductTemplate_not_found_with_id(request.ProductTemplateId)), nameof(request.ProductTemplateId)));
                }
                var templates = new List<TemplateResponse>();
                foreach(var ts in productTemplate.TemplateSteps)
                {
                    var templateStep = new TemplateResponse(ts);
                    var its = new List<IngredientTypeResponse>();
                    foreach(var it in ts.IngredientTypeTemplateSteps)
                    {
                        var ingreStep = new IngredientTypeResponse(it);
                        its.Add(ingreStep);
                    }
                    templateStep.IngredientTypes = its;
                    templates.Add(templateStep);
                }
                var result = new ProductTemplateResponse
                {
                    Id = productTemplate.Id,
                    Name = productTemplate.Name,
                    Templates = templates,
                };

                return new BaseResult<ProductTemplateResponse>(result);
            }
            catch (Exception ex)
            {
                return new BaseResult($"An error occurred while get all the template: {ex.Message}");
            }
        }

        public async Task<BaseResult> GetById(GetTemplateByIdRequest request)
        {
            try
            { 
                var templateStep = await _context.TemplateSteps.Include(c => c.IngredientTypeTemplateSteps)
                    .ThenInclude(c => c.IngredientType)
                    .FirstOrDefaultAsync(c=> c.Id == request.TemplateStepId);
                if (templateStep == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.TemplateStepMessages.TemplateStep_not_found_with_id(request.TemplateStepId)), nameof(request.TemplateStepId)));
                }
                
                var its = new List<IngredientTypeResponse>();
                foreach (var it in templateStep.IngredientTypeTemplateSteps)
                {
                    var ingreStep = new IngredientTypeResponse(it);
                    its.Add(ingreStep);
                }
                var resutl = new TemplateResponse(templateStep);
                resutl.IngredientTypes = its;
                return new BaseResult<TemplateResponse>(resutl);
            }
            catch (Exception ex)
            {
                return new BaseResult($"An error occurred while get the template: {ex.Message}");
            }
        }

        public async Task<BaseResult> UpdateTempalte(CreateTemplateRequest request)
        {
            try
            {
                var templateStep = await _context.TemplateSteps.FirstOrDefaultAsync(c => c.Id == request.TemplateStepId);

                if (templateStep == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.TemplateStepMessages.TemplateStep_not_found_with_id(request.TemplateStepId)), nameof(request.TemplateStepId)));
                }
                foreach (var ingreType in request.IngredientType)
                {
                    var ingredientType = await _context.IngredientTypes.FirstOrDefaultAsync(i => i.Id == ingreType.IngredientTypeId);
                    if (ingredientType == null)
                    {
                        return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.IngredientTypeMessages.IngredientType_not_Found_with_id(ingreType.IngredientTypeId)), nameof(ingreType.IngredientTypeId)));
                    }
                }
                var existsTemplate = await _context.IngredientTypeTemplateSteps
                    .Where(c=> c.TemplateStepId == request.TemplateStepId).ToListAsync();
                if (existsTemplate.Any())
                {
                    _context.IngredientTypeTemplateSteps.RemoveRange(existsTemplate);
                }

                foreach (var newIngredientType in request.IngredientType)
                {
                    var ingredientProduct = new IngredientTypeTemplateStep
                    {
                        TemplateStepId = request.TemplateStepId,
                        IngredientTypeId = newIngredientType.IngredientTypeId,
                        QuantityMax = newIngredientType.QuantityMax,
                        QuantityMin = newIngredientType.QuantityMin,
                    };
                    await _context.IngredientTypeTemplateSteps.AddAsync(ingredientProduct);
                }
                templateStep.Update((int)TemplateStepStatus.Active);
                await _unitOfWork.SaveChangesAsync();
                return new BaseResult();
            }
            catch (Exception ex)
            {
                return new BaseResult($"An error occurred while Update the template: {ex.Message}");
            }
        }

        public async Task<BaseResult> UpdateTemplateStatus(UpdateTemplateStatusRequest request)
        {
            try
            {
                var productTemplate = await _context.ProductTemplates
                                    .Include(c => c.TemplateSteps)
                                    .FirstOrDefaultAsync(c => c.Id == request.ProductTemplateId);

                if (productTemplate == null)
                {
                    return new BaseResult(new Error(ErrorCode.NotFound, _translator.GetString(TranslatorMessages.ProductTemplateMessages.ProductTemplate_not_found_with_id(request.ProductTemplateId)), nameof(request.ProductTemplateId)));
                }
                if (productTemplate.TemplateSteps.Any(c => c.Status == (int)TemplateStepStatus.Inactive))
                {
                    return new BaseResult(new Error(ErrorCode.Exception, _translator.GetString(TranslatorMessages.ProductTemplateMessages.ProductTemplate_existed_inative_step(request.ProductTemplateId)), nameof(request.ProductTemplateId)));
                }
                productTemplate.Status = (int)ProductTemplateStatus.Active;
                await _unitOfWork.SaveChangesAsync();
                return new BaseResult();
            }
            catch(Exception ex)
            {
                return new BaseResult($"An error occurred while Update status the template: {ex.Message}");
            }
        }
    }
}
