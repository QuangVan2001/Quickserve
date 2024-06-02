using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Stores.Dtos;

namespace QuickServe.Application.Features.Store.Queries.GetStoreEmployees
{
    public class GetPagedListStoreEmployeesQuery : PagenationRequestParameter, IRequest<PagedResponse<EmployeeDto>>
    {
        public long StoreId { get; set; }
        public string Name { get; set; }
    }
}