
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology
{
    internal class UpdatedProgrammingTechnologyCommandValidator : AbstractValidator<UpdateProgrammingTechnologyCommand>
    {
        public UpdatedProgrammingTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("notempty");
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty().WithMessage("notempty");


        }

    }
}
