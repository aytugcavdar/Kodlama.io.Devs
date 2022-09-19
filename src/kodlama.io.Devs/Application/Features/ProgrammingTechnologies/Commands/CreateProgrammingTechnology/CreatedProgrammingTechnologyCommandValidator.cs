using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreatedProgrammingTechnologyCommandValidator : AbstractValidator<CreateProgrammingTechnologyCommand>
    {
        public CreatedProgrammingTechnologyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("notempty");
            RuleFor(c => c.ProgrammingLanguageId).NotEmpty().WithMessage("notempty");
           
        
        }
    
    }
}
