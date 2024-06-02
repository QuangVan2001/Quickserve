using MediatR;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;
using System.Threading;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Store.Queries.GetStoreEmployees
{
    public class GetPagedListStoreEmployeesQueryHandler(IStaffRepository staffRepository) : IRequestHandler<GetPagedListStoreEmployeesQuery, PagedResponse<EmployeeDto>>
    {
        public async Task<PagedResponse<EmployeeDto>> Handle(GetPagedListStoreEmployeesQuery request, CancellationToken cancellationToken)
        {
            var result =  await staffRepository.GetPagedListStaffByStoreIdAsync(request.StoreId, request.PageNumber, request.PageSize, request.Name, cancellationToken);
            return new PagedResponse<EmployeeDto>(result, request);
        }
    }
}
