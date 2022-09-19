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

namespace Application.Features.SocialMedia.GitHubProfile.Commands.DeleteGitHub
{
    public class DeleteGitHubCommand:IRequest<DeletedGitHubDto>
    {
        public int Id { get; set; }

        public class DeleteGitHubCommandHandler : IRequestHandler<DeleteGitHubCommand, DeletedGitHubDto>
        {
            private readonly IGitHubRepository _gitHubRepository;
            private readonly IMapper _mapper;
            private readonly GitHubBusinessRules _gitHubBusinessRules;

            public DeleteGitHubCommandHandler(IGitHubRepository gitHubRepository, IMapper mapper, GitHubBusinessRules gitHubBusinessRules)
            {
                _gitHubRepository = gitHubRepository;
                _mapper = mapper;
                _gitHubBusinessRules = gitHubBusinessRules;
            }

            public async Task<DeletedGitHubDto> Handle(DeleteGitHubCommand request, CancellationToken cancellationToken)
            {
              
                var control = await _gitHubRepository.GetAsync(c=>c.Id==request.Id);
                 _gitHubBusinessRules.GithubAccountMustExistWhenRequested(control);
                var deleteGitHub = await _gitHubRepository.DeleteAsync(control);

                DeletedGitHubDto deletedGitHubDto = _mapper.Map<DeletedGitHubDto>(deleteGitHub);
                return deletedGitHubDto;

            }
        }
    }
}
