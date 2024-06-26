﻿using FluentValidation;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces;

namespace QuickServe.Application.DTOs.Account.Requests
{
    public class AuthenticationRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator(ITranslator translator)
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithName(p => translator[nameof(p.Email)]);

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .Matches(Regexs.Password)
                .WithName(p => translator[nameof(p.Password)]);
        }
    }
}
