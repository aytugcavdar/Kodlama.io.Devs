using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Rules;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Queries.GetListByIdProgrammingTechnologyQuery
{
    public class GetListByIdProgrammingTechnologyQuery:IRequest<GetListByIdProgrammingTechnologyDto>
    {
        public int Id { get; set; }

        public class GetListByIdProgrammingTechnologyQueryHandler : IRequestHandler<GetListByIdProgrammingTechnologyQuery, GetListByIdProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologiesBusinessRules _programmingTechnologiesBusinessRules;

            public GetListByIdProgrammingTechnologyQueryHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologiesBusinessRules programmingTechnologiesBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologiesBusinessRules = programmingTechnologiesBusinessRules;
            }

            public async Task<GetListByIdProgrammingTechnologyDto> Handle(GetListByIdProgrammingTechnologyQuery request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology control =await _programmingTechnologyRepository.GetAsync(predicate:c => c.Id == request.Id
               
                    );

                 _programmingTechnologiesBusinessRules.ProgrammingTechnologyShouldExistWhenRequested(control);
                GetListByIdProgrammingTechnologyDto listByIdProgrammingTechnologyDto = _mapper.Map<GetListByIdProgrammingTechnologyDto>(control);

                return listByIdProgrammingTechnologyDto;

            }
        }
    }
}
