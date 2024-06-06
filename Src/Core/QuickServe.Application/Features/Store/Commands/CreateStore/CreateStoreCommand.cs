using System;
using MediatR;
using QuickServe.Application.Wrappers;

namespace QuickServe.Application.Features.Store.Commands.CreateStore;

public class CreateStoreCommand : IRequest<BaseResult<long>>
{
    public string Name { get; set; }
    public string Address { get; set; }
   
}