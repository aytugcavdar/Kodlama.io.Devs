using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguages
{
    public class CreatedProgrammingLanguageCommandValidator : AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreatedProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("bomboş şeyi neden bana yolluyon");
            
        }
    }
}
