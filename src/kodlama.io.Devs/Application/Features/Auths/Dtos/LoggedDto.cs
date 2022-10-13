using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Dtos
{
    public class LoggedDto
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }


        public LoggedResponseDto CreateResponseDto()
        {
            return new() { AccessToken = AccessToken };
        }


        public class LoggedResponseDto
        {
            public AccessToken? AccessToken { get; set; }
            
        }

    }
}
