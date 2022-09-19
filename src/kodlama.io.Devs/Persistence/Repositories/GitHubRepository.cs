using Application.Services.Repositories;
using Domain.Entities;
using Kodlama.io.Persistence.Repositories;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class GitHubRepository : EfRepositoryBase<GitHub, BaseDbContext>, IGitHubRepository
    {
        public GitHubRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
