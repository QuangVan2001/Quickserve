﻿using MediatR;
using QuickServe.Application.Wrappers;
using System;

namespace QuickServe.Application.Features.Store.Commands.AddEmployee
{
    public class AddEmployeeCommand : IRequest<BaseResult<Guid>>
    {
        public long StoreId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
