using Application.Services.Repositories;
using Kodlama.io.Core.CrossCuttingConcers.Exceptions;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimIdShouldExistWhenSelected(int id)
        {
            OperationClaim? result = await _operationClaimRepository.GetAsync(b => b.Id == id);
            if (result == null) throw new BusinessException("OperationClaim not exists.");
        }
        public async Task OperationClaimNameCanNotBeDublicatedWhenInserted(string name)
        {

            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Bu isimde claim  zaten var.");
        }
    }
}
