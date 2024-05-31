using QuickServe.Application.DTOs;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.TemplateSteps.Dtos;
using QuickServe.Domain.TemplateSteps.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Interfaces.Repositories
{
    public interface ITemplateStepRepository : IGenericRepository<TemplateStep>
    {
        Task<TemplateStep> FindByIdAsync(long id);
        Task<PagenationResponseDto<TemplateStepDTO>> GetPagedListAsync(long productTemplateId, int pageNumber, int pageSize, string name);
        Task<PagenationResponseDto<TemplateStepDTO>> GetPagedListByAcitveStatusAsync(long productTemplateId, int pageNumber, int pageSize, string name);
        Task<bool> ExistNameAsync(long productTemplateId, string name);
    }
}
