using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GitHub:Entity
    {
        public int UserId { get; set; }

        public string GitHubProfileLink { get; set; }

        public virtual User? User { get; set; }

        public GitHub()
        {

        }

        public GitHub(int id,int userId, string gitHubProfileLink, User user):this()
        {
            Id = id;
            UserId = userId;
            GitHubProfileLink = gitHubProfileLink;
            User = user;
        }
    }
}
