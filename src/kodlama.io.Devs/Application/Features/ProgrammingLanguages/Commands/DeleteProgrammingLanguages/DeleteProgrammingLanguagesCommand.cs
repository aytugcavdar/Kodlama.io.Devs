using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguages
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguagesCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public DeleteProgrammingLanguagesCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                var control = await _programmingLanguageRepository.GetAsync(c => c.Id == request.Id);

                _programmingLanguagesBusinessRules.ProgrammingLanguageShouldExistWhenRequested(control);
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.DeleteAsync(control);

                DeleteProgrammingLanguageDto deleteProgrammingLanguage = _mapper.Map<DeleteProgrammingLanguageDto>(programmingLanguage);

                return deleteProgrammingLanguage;
            }
        }
    }
}
