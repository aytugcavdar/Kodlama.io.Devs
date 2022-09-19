using Application.Services.Repositories;
using Kodlama.io.Core.CrossCuttingConcers.Exceptions;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCanNotBeDuplicatedWhenInserted(string email)
        {
            var result = await _userRepository.GetAsync(user => user.Email == email);
            if (result is not null) throw new BusinessException("Email address exists");
        }
        public async Task CheckIfUserExists(string email)
        {
            var result = await _userRepository.GetAsync(user => user.Email == email);
            if (result is null) throw new BusinessException("Email address exists");
        }


        public void CheckIfThePasswordIsCorrect(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt))
                throw new BusinessException("Please make sure you entered your password correctly");
        }

    }
}
