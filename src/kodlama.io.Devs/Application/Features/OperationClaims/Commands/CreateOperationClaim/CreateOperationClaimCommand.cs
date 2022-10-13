using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Kodlama.io.Core.Application.Pipelines.Authorization;
using Kodlama.io.Core.Security.Entities;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand:IRequest<CreatedOperationClaimDto>, ISecuredRequest
    {
        public string Name { get; set; }

        public string[] Roles => new[] { "Admin" };

        public class
            CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
                                                      OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request,
                                                               CancellationToken cancellationToken)
            {

                await _operationClaimBusinessRules.OperationClaimNameCanNotBeDublicatedWhenInserted(request.Name);

                OperationClaim mappedClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim createdClaim = await _operationClaimRepository.AddAsync(mappedClaim);
                CreatedOperationClaimDto claimDto = _mapper.Map<CreatedOperationClaimDto>(createdClaim); ;
                return claimDto;



               
            }
        }
    }
}
