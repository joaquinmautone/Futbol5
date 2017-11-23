using Futbol5.DAL.Infrastructure;
using Futbol5.Entities;

namespace Futbol5.DAL.Repositories
{
    public class EquipoRepository : RepositoryBase<Equipo>, IEquipoRepository
    {
        public EquipoRepository(IDatabaseFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IEquipoRepository : IRepository<Equipo>
    {

    }
}
