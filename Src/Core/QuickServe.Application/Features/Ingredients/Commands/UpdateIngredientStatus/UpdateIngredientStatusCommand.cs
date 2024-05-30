using MediatR;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Ingredients.Commands.UpdateIngredientStatus
{
    public class UpdateIngredientStatusCommand : IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
