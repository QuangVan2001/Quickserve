using FluentValidation;
using QuickServe.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.Sessions.Queries.GetPagedListSession
{
    public class GetPagedListSessionQueryValidator : AbstractValidator<GetPagedListSessionQuery>
    {
        public GetPagedListSessionQueryValidator(ITranslator translator)
        {
            RuleFor(x => x.StoreId)
                .GreaterThan(0).WithMessage(translator["Id của cửa hàng phải lớn hơn 0"])
                .WithName(p => translator[nameof(p.StoreId)]);
        }
    }
}
