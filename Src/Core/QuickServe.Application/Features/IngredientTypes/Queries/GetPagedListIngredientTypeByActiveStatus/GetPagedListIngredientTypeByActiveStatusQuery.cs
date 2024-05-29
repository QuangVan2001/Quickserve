using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Dtos;
using QuickServe.Domain.IngredientTypes.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.IngredientTypes.Queries.GetPagedListIngredientTypeByActiveStatus
{
    public class GetPagedListIngredientTypeByActiveStatusQuery : PagenationRequestParameter, IRequest<PagedResponse<IngredientTypeDTO>>
    {
        public string Name { get; set; }
    }
}