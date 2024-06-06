using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces.UserInterfaces;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Wrappers;
using QuickServe.Utils.Enums;
using System;
using System.Threading;
using System.Threading.Tasks;
using QuickServe.Application.Features.Accounts.Commands;

namespace QuickServe.Application.Features.Store.Commands.AddEmployee
{
    public class AddEmployeeCommandHandler(IStaffRepository staffRepository, IAccountServices accountServices, ITranslator translator, IMediator mediator) : IRequestHandler<AddEmployeeCommand, BaseResult<Guid>>
    {
        public async Task<BaseResult<Guid>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(new CreateAccountCommand { Email = request.Email, UserName = request.UserName, Password = request.Password, Role = AccountRole.Staff.ToString() }, cancellationToken);
                staffRepository.AddStaffToStore(request.StoreId, result.Data);
                return new BaseResult<Guid>(result.Data);
            }
            catch (Exception ex)
            {
                return new BaseResult<Guid>(new Error(ErrorCode.DatabaseCommitException, translator.GetString(ex.Message), nameof(AddEmployeeCommand)));
            }
        }
    }
}
