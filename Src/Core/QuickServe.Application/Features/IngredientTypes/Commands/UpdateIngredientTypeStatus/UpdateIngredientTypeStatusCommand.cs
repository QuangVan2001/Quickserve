using MediatR;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.IngredientTypes.Commands.UpdateIngredientTypeStatus
{
    public class UpdateIngredientTypeStatusCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
