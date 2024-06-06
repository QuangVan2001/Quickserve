using MediatR;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Dtos;
using System;

namespace QuickServe.Application.Features.Accounts.Queries.GetAccountById;

public class GetAccountByIdQuery : IRequest<BaseResult<AccountDto>>
{
    public Guid Id { get; set; }
}