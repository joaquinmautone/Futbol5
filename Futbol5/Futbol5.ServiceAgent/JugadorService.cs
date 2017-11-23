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
    public class JugadorService : IJugadorService
    {
        private IJugadorRepository repository;
        private IUnitOfWork unitOfWork;

        public JugadorService(IJugadorRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Jugador> ObtenerJugadores()
        {
            return repository.GetAll();
        }

        public Jugador AgregarJugador(Jugador jugador)
        {
            repository.Add(jugador);
            SaveChanges();

            return jugador;
        }

        public Jugador ObtenerJugadorPorId(int id)
        {
            return repository.GetById(id);
        }

        public Jugador ModificarJugador(Jugador jugador)
        {
            repository.Update(jugador);
            SaveChanges();

            return jugador;
        }

        public void EliminarJugador(int id)
        {
            var jugador = repository.GetById(id);
            repository.Delete(jugador);

            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface IJugadorService
    {
        IEnumerable<Jugador> ObtenerJugadores();
        Jugador AgregarJugador(Jugador jugador);
        Jugador ObtenerJugadorPorId(int id);
        Jugador ModificarJugador(Jugador jugador);
        void EliminarJugador(int jugadorId);
    }
}
