using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Categories.Queries.GetPagedListCategoryByActiveStatus
{
    public class GetPagedListCategoryByActiveStatusQuery : PagenationRequestParameter, IRequest<PagedResponse<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
