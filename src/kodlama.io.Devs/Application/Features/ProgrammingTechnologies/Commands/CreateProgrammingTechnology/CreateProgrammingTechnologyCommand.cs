using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand:IRequest<CreatedProgrammingTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologiesBusinessRules _programmingTechnologiesBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologiesBusinessRules programmingTechnologiesBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologiesBusinessRules = programmingTechnologiesBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
               
                await _programmingTechnologiesBusinessRules.ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

               // ProgrammingLanguage control =await  _programmingLanguageRepository.GetAsync(c => c.Id == request.ProgrammingLanguageId);
                // _programmingTechnologiesBusinessRules.ProgrammingLanguageShouldExistWhenRequested(control);

                request.ImageUrl  =  await _programmingTechnologiesBusinessRules.ProgrammingTechnologyDefaultImageUrl(request.ImageUrl);



                ProgrammingTechnology programmingTechnology =  _mapper.Map<ProgrammingTechnology>(request);


                

                ProgrammingTechnology createdProgrammingTechnology = await _programmingTechnologyRepository.AddAsync(programmingTechnology);

                CreatedProgrammingTechnologyDto created = _mapper.Map<CreatedProgrammingTechnologyDto>(createdProgrammingTechnology);

                return created;
            }







        }
    }
}
