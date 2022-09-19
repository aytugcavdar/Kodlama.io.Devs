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

namespace Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology
{
    public class DeleteProgrammingTechnologyCommand:IRequest<DeletedProgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingTechnologyCommandHandler : IRequestHandler<DeleteProgrammingTechnologyCommand, DeletedProgrammingTechnologyDto>
        {

            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologiesBusinessRules _programmingTechnologiesBusinessRules;

            public DeleteProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologiesBusinessRules programmingTechnologiesBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologiesBusinessRules = programmingTechnologiesBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyDto> Handle(DeleteProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                var control = await _programmingTechnologyRepository.GetAsync(c => c.Id == request.Id);

                _programmingTechnologiesBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(control);


                ProgrammingTechnology programmingTechnology =await _programmingTechnologyRepository.DeleteAsync(control);

                DeletedProgrammingTechnologyDto deleted = _mapper.Map<DeletedProgrammingTechnologyDto>(programmingTechnology);

                return deleted;



            }
        }

    }
}
