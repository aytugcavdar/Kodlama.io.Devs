using Domain.Entities;
using Kodlama.io.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Repositories
{
    public interface IGitHubRepository : IAsyncRepository<GitHub>, IRepository<GitHub>
    {
    }
}
