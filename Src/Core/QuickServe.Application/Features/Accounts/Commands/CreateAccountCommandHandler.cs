using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Accounts.Entities;
using QuickServe.Utils.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Accounts.Commands
{
    public class CreateAccountCommandHandler(IAccountServices accountServices, IStaffRepository staffRepository ,IGenericRepository<Account> accountRepository) : IRequestHandler<CreateAccountCommand, BaseResult<Guid>>
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
                    Id = result.Data,
                    Name = ""
                };

                await accountRepository.AddAsync(account);
                if (request.Role == AccountRole.Staff.ToString() ||
                    request.Role == AccountRole.Store_Manager.ToString())
                {
                    staffRepository.AddStaffToStore(request.StoreId, account.Id);
                }
                return new BaseResult<Guid>(account.Id);
            }
            return new BaseResult<Guid>(result.Errors);
        }
    }
}
