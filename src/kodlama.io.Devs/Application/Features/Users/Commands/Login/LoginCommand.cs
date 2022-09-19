
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Login
{
    public class LoginCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, AccessToken>
        {

            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly ITokenHelper _tokenHelper;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _authBusinessRules = authBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _userRepository.GetAsync(x => x.Email == request.Email);
                 await _authBusinessRules.CheckIfUserExists(request.Email);
                _authBusinessRules.CheckIfThePasswordIsCorrect(request.Password, user.PasswordHash, user.PasswordSalt);

                var userClaims = await _userOperationClaimRepository.GetListAsync(
                 x => x.UserId == user.Id,
                 include: x => x.Include(cl => cl.OperationClaim),
                 cancellationToken: cancellationToken
                );

                var token = _tokenHelper.CreateToken(user, userClaims.Items.Select(x => x.OperationClaim).ToList());

                return new() { Token = token.Token, Expiration = token.Expiration };
            }
        }
    }
}
