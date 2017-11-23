using Futbol5.DAL.Infrastructure;
using Futbol5.Entities;

namespace Futbol5.DAL.Repositories
{
    public class CampeonatoRepository : RepositoryBase<Campeonato>, ICampeonatoRepository
    {
        public CampeonatoRepository(IDatabaseFactory dbFactory): base(dbFactory)
        {

        }
    }

    public interface ICampeonatoRepository : IRepository<Campeonato>
    {

    }
}
