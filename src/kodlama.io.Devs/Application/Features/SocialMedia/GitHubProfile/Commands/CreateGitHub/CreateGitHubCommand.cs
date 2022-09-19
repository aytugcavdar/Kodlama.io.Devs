using Application.Features.SocialMedia.GitHubProfile.Dtos;
using Application.Features.SocialMedia.GitHubProfile.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.GitHubProfile.commands.CreateGitHub
{
    public class CreateGitHubCommand:IRequest<CreatedGitHubDto>
    {
        public int UserId { get; set; }

        public string GitHubProfileLink { get; set; }

        public class CreateGitHubCommandHandler : IRequestHandler<CreateGitHubCommand, CreatedGitHubDto>
        {
            private readonly IGitHubRepository _gitHubRepository;
            private readonly IMapper _mapper;
            private readonly GitHubBusinessRules _gitHubBusinessRules;

            public CreateGitHubCommandHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules)
            {
                _gitHubRepository = gitHubRepository;
                _mapper = mapper;
                _gitHubBusinessRules = gitHubBusinessRules;
            }

            public async Task<CreatedGitHubDto> Handle(CreateGitHubCommand request, CancellationToken cancellationToken)
            {
                var github = _mapper.Map<GitHub>(request);

             

                var addGithub = await _gitHubRepository.AddAsync(github);

                var createdDto = _mapper.Map<CreatedGitHubDto>(github);

                return createdDto;
            }
        }
    }
}
