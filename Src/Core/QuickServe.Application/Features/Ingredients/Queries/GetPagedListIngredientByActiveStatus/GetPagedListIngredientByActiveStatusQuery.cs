using MediatR;
using QuickServe.Application.Parameters;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Ingredients.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Ingredients.Queries.GetPagedListIngredientByActiveStatus
{
    public class GetPagedListIngredientByActiveStatusQuery : PagenationRequestParameter, IRequest<PagedResponse<IngredientDTO>>
    {
        public string Name { get; set; }
    }
}