using Application.Features.SocialMedia.GitHubProfile.Dtos;
using Application.Features.SocialMedia.GitHubProfile.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.GitHubProfile.Commands.UpdateGitHub
{
    public class UpdateGitHubCommand:IRequest<UpdatedGitHubDto>
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string GitHubProfileLink { get; set; }

        public class UpdatedGitHubDtoHandler : IRequestHandler<UpdateGitHubCommand, UpdatedGitHubDto>
        {
            private readonly IGitHubRepository _gitHubRepository;
            private readonly IMapper _mapper;
            private readonly GitHubBusinessRules _gitHubBusinessRules;

            public UpdatedGitHubDtoHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules)
            {
                _gitHubRepository = gitHubRepository;
                _mapper = mapper;
                _gitHubBusinessRules = gitHubBusinessRules;
            }

            public async Task<UpdatedGitHubDto> Handle(UpdateGitHubCommand request, CancellationToken cancellationToken)
            {
                

                var control = await _gitHubRepository.GetAsync(c => c.Id == request.Id);
                _gitHubBusinessRules.GithubAccountMustExistWhenRequested(control);
               

                var result = _mapper.Map(request, control);

                var updatedGitHub = await _gitHubRepository.UpdateAsync(result);

                UpdatedGitHubDto updatedGitHubDto = _mapper.Map<UpdatedGitHubDto>(updatedGitHub);

                return updatedGitHubDto;



            }
        }
    }
}
