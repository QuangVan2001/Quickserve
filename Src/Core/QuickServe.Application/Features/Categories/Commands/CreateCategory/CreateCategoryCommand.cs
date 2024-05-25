using System;
using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<BaseResult<long>>
{
    public string Name { get; set; }
 
}