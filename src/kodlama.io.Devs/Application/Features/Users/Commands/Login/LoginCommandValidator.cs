using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Login
{
    internal class LoginCommandValidator : AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Not Empty");
            RuleFor(x => x.Email).EmailAddress().WithMessage("düzgün yazarmısın ");
            RuleFor(x => x.Password).MinimumLength(5);
            
        }
    }
}
