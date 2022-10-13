using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Kodlama.io.Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimDto>
    {
        public int Id { get; set; }

        public class GetByIdOperationClaimQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper,
                                                     OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }


            public async Task<OperationClaimDto> Handle(GetByIdOperationClaimQuery request,CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimIdShouldExistWhenSelected(request.Id);

                 OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(b => b.Id == request.Id);
                OperationClaimDto operationClaimDto1 = _mapper.Map<OperationClaimDto>(operationClaim);

                var a = operationClaimDto1;

                OperationClaimDto operationClaimDto = new OperationClaimDto { Id = operationClaim.Id,Name = operationClaim.Name };



                return operationClaimDto;
            }
        }
    }
}
