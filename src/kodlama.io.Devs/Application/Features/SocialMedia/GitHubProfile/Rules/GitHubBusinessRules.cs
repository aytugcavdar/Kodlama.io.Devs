using Application.Services.Repositories;
using Domain.Entities;
using Kodlama.io.Core.CrossCuttingConcers.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.GitHubProfile.Rules
{
    public class GitHubBusinessRules
    {
        private readonly IGitHubRepository _gitHubRepository;

        private readonly IUserRepository _userRepository;

        public GitHubBusinessRules(IGitHubRepository gitHubRepository, IUserRepository userRepository)
        {
            _gitHubRepository = gitHubRepository;
            _userRepository = userRepository;
        }

        public void GithubAccountMustExistWhenRequested(GitHub github)
        {
            if (github == null) throw new BusinessException("Github Account must exist.");
        }
        public async Task GithubAccountCanNotBeInsertedWhenMemberAlreadyHaveOne(GitHub github)
        {
            GitHub? git = await _gitHubRepository.GetAsync(g => g.UserId == github.UserId);

            if (git != null) throw new BusinessException("One member can't have two github profiles!");
        }

    }
}
