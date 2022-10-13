using Kodlama.io.Core.Security.Entities;
using Kodlama.io.Persistence.Repositories;

namespace Application.Services.Repositories
{
    public interface IRefreshRepository : IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {

    }

}    
