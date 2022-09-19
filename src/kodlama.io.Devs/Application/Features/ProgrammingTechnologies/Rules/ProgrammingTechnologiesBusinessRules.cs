using Application.Services.Repositories;
using Domain.Entities;
using Kodlama.io.Core.CrossCuttingConcers.Exceptions;
using Kodlama.io.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingTechnologies.Rules
{
    public class ProgrammingTechnologiesBusinessRules
    {
        private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;

        public ProgrammingTechnologiesBusinessRules(IProgrammingTechnologyRepository programmingTechnologyRepository)
        {
            _programmingTechnologyRepository = programmingTechnologyRepository;
        }
        public async Task ProgrammingTechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingTechnology> result = await _programmingTechnologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("BUNDAN BİZDE VAR !");
        }

        public void ProgrammingTechnologyShouldExistWhenRequested(ProgrammingTechnology programmingTechnology)
        {
            if (programmingTechnology == null) throw new BusinessException("BULAMADIM");
        }
        public async Task<string> ProgrammingTechnologyDefaultImageUrl(string imageurl)
        {
            if(imageurl=="" || imageurl == null)
            {
                imageurl = "default.png";
            }
            return imageurl;
        }
        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Böyle bir dil yok");
        }
    }
}
