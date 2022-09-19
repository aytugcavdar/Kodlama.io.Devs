using Application.Services.Repositories;
using Domain.Entities;
using Kodlama.io.Persistence.Repositories;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ProgrammingTechnologyRepository : EfRepositoryBase<ProgrammingTechnology, BaseDbContext>, IProgrammingTechnologyRepository
    {
        public ProgrammingTechnologyRepository(BaseDbContext context) : base(context)
        {

        }
    }
}
