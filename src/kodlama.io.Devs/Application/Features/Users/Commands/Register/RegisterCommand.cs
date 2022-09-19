
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Kodlama.io.Core.Security.Dtos;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Core.Security.Hashing;
using Kodlama.io.Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.Register
{
    public class RegisterCommand :IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class RegisterUserAppCommandHandler :IRequestHandler<RegisterCommand, AccessToken>
    {
        private readonly IUserRepository _registerRepository;
        private readonly IMapper _mapper;
        private readonly ITokenHelper _tokenHelper;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public RegisterUserAppCommandHandler(IUserRepository registerRepository, IMapper mapper, ITokenHelper tokenHelper,AuthBusinessRules authBusinessRules, IUserOperationClaimRepository userOperationClaimRepository, IOperationClaimRepository operationClaimRepository)
        {
            _registerRepository = registerRepository;
            _mapper = mapper;
            _tokenHelper = tokenHelper;
            _userOperationClaimRepository = userOperationClaimRepository;
            _authBusinessRules = authBusinessRules;
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task<AccessToken> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailCanNotBeDuplicatedWhenInserted(request.Email);
            
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

            

            User user = _mapper.Map<User>(request);
           
            
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;



            OperationClaim? claim = await _operationClaimRepository.GetAsync(x => x.Name == "User");
           
            User newUser = await _registerRepository.AddAsync(user);

            
            UserOperationClaim userOperationClaim = new UserOperationClaim { UserId = newUser.Id, OperationClaimId = claim.Id };
            await _userOperationClaimRepository.AddAsync(userOperationClaim);

            var userClaims = await _userOperationClaimRepository.GetListAsync(
                x => x.UserId == newUser.Id,
                include: x => x.Include(cl => cl.OperationClaim),
                cancellationToken: cancellationToken
                );

            var token = _tokenHelper.CreateToken(newUser, userClaims.Items.Select(x => x.OperationClaim).ToList());

            return new() { Token=token.Token,Expiration=token.Expiration};
        }
    }
}
