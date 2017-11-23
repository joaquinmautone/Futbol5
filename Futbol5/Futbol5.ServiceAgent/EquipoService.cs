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
    public class EquipoService : IEquipoService
    {
        private IEquipoRepository repository;
        private IUnitOfWork unitOfWork;

        public EquipoService(IEquipoRepository repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Equipo> ObtenerEquipos()
        {
            return repository.GetAll();
        }

        public Equipo AgregarEquipo(Equipo equipo)
        {
            repository.Add(equipo);
            SaveChanges();

            return equipo;
        }

        public Equipo ObtenerEquipoPorId(int id)
        {
            return repository.GetById(id);
        }

        public Equipo ModificarEquipo(Equipo equipo)
        {
            repository.Update(equipo);
            SaveChanges();

            return equipo;
        }

        public void EliminarEquipo(int id)
        {
            var equipo = repository.GetById(id);
            repository.Delete(equipo);

            SaveChanges();
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }

    public interface IEquipoService
    {
        IEnumerable<Equipo> ObtenerEquipos();
        Equipo AgregarEquipo(Equipo equipo);
        Equipo ObtenerEquipoPorId(int id);
        Equipo ModificarEquipo(Equipo equipo);
        void EliminarEquipo(int equipoId);
    }
}
