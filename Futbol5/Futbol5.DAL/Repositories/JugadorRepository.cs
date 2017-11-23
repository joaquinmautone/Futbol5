using Futbol5.DAL.Infrastructure;
using Futbol5.Entities;

namespace Futbol5.DAL.Repositories
{
    public class JugadorRepository : RepositoryBase<Jugador>, IJugadorRepository
    {
        public JugadorRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IJugadorRepository : IRepository<Jugador>
    {

    }
}