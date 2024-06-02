using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Accounts.Commands
{
    public class CreateAccountCommandHandler(IAccountServices accountServices, IGenericRepository<Account> accountRepository) : IRequestHandler<CreateAccountCommand, BaseResult<Guid>>
    {
        public async Task<BaseResult<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {
            var result = await accountServices.CreateAccount(new DTOs.Account.Requests.CreateAccountRequest
            {
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
                UserName = request.UserName
            });
            if (result.Success)
            {
                var account = new Account
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    Name = request.UserName
                };
                await accountRepository.AddAsync(account);
                return new BaseResult<Guid>(account.Id);
            }
            return new BaseResult<Guid>(result.Errors);
        }
    }
}
