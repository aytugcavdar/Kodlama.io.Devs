using Application.Services.Repositories;
using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Persistence.Repositories;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {

        }
    }
    public class RefreshRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshRepository
    {
        public RefreshRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
