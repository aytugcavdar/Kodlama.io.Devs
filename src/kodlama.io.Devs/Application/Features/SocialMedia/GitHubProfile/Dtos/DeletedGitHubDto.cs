using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.GitHubProfile.Dtos
{
    public class DeletedGitHubDto
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string GitHubProfileLink { get; set; }
    }
}
