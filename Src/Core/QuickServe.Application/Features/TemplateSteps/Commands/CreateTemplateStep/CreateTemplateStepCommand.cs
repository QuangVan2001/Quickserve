﻿using MediatR;
using QuickServe.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickServe.Application.Features.TemplateSteps.Commands.CreateTemplateStep
{
    public class CreateTemplateStepCommand : IRequest<BaseResult>
    {
        public long ProductTemplateId { get; set; }
        public string Name { get; set; }

    }
}