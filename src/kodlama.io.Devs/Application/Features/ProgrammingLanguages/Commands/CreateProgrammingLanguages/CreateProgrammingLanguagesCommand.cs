using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;

using Domain.Entities;
using Kodlama.io.Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguages
{
    public  class CreateProgrammingLanguageCommand:IRequest<CreatedProgrammingLanguageDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new string[] { "Admin" };
        public class CreateProgrammingLanguagesCommandHandler:IRequestHandler<CreateProgrammingLanguageCommand, CreatedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public CreateProgrammingLanguagesCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper,ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            




            public async Task<CreatedProgrammingLanguageDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguagesBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
                CreatedProgrammingLanguageDto programmingLanguagesDto = _mapper.Map<CreatedProgrammingLanguageDto>(createdProgrammingLanguage);
                return programmingLanguagesDto;
                
            }
        }
    }
}
