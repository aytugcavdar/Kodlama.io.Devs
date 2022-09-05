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

namespace Application.Features.ProgrammingLanguages.Queries.GetListByIdProgrammingLanguage
{
    public class GetListByIdProgrammingLanguageQuery : IRequest<ProgrammingLanguageListByIdDto>
    {
        public int Id { get; set; }

        public class GetListByIdProgrammingLanguageQueryHandler : IRequestHandler<GetListByIdProgrammingLanguageQuery, ProgrammingLanguageListByIdDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;
            public GetListByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper,ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _mapper = mapper;
                _programmingLanguageRepository = programmingLanguageRepository;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

        public async Task<ProgrammingLanguageListByIdDto> Handle(GetListByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

                _programmingLanguagesBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                ProgrammingLanguageListByIdDto programmingLanguageListByIdDto = _mapper.Map<ProgrammingLanguageListByIdDto>(programmingLanguage);

                return programmingLanguageListByIdDto;

            }
        }
    }
}
