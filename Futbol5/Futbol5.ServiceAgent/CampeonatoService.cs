using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Futbol5.DAL.Repositories;
using Futbol5.DAL.Infrastructure;
using Futbol5.Entities;

namespace Futbol5.ServiceAgent
{
    public class CampeonatoService : ICampeonatoService
    {
        private ICampeonatoRepository repository;
        private IUnitOfWork unitOfWork;

        public CampeonatoService(ICampeonatoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Campeonato> ObtenerCampeonatos()
        {
            return repository.GetAll();
        }

        public Campeonato AgregarCampeonato(Campeonato campeonato)
        {
            repository.Add(campeonato);
            SaveChanges();

            return campeonato;
        }

        public Campeonato ObtenerCampeonatoPorId(int id)
        {
            return repository.GetById(id);
        }

        public Campeonato ModificarCampeonato(Campeonato campeonato)
        {
            repository.Update(campeonato);
            SaveChanges();

            return campeonato;
        }

        public void EliminarCampeonato(int id)
        {
            var campeonato = repository.GetById(id);
            repository.Delete(campeonato);

            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface ICampeonatoService
    {
        IEnumerable<Campeonato> ObtenerCampeonatos();
        Campeonato AgregarCampeonato(Campeonato campeonato);
        Campeonato ObtenerCampeonatoPorId(int id);
        Campeonato ModificarCampeonato(Campeonato campeonato);
        void EliminarCampeonato(int campeonatoId);
    }
}
