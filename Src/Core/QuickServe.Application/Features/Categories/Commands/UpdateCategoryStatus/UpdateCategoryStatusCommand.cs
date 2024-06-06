using MediatR;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Categories.Commands.UpdateCategoryStatus
{
    public class UpdateCategoryStatusCommand :IRequest<BaseResult>
    {
        public long Id { get; set; }
    }
}
