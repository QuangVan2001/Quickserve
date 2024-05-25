using System.Threading;
using System.Threading.Tasks;
using MediatR;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Entities;

namespace QuickServe.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateCategoryCommand, BaseResult<long>>
{
    public async Task<BaseResult<long>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = new Category(request.Name);
         await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult<long>(category.Id);
    }
}