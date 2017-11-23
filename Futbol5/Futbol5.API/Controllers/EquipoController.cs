using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Futbol5.Entities;
using Futbol5.API.ViewModels;
using Futbol5.ServiceAgent;
using AutoMapper;

namespace Futbol5.API.Controllers
{
    public class EquipoController : ApiController
    {
        private readonly IEquipoService equipoService;

        public EquipoController() : base()
        {

        }

        public EquipoController(IEquipoService equipoService)
        {
            this.equipoService = equipoService;
        }

        [HttpGet]
        public IHttpActionResult ObtenerEquipos()
        {
            var equipos = equipoService.ObtenerEquipos();
            var equiposVM = new List<EquipoViewModel>();
            Mapper.Map(equipos, equiposVM);

            return Ok(equiposVM);
        }

        [HttpGet]
        public IHttpActionResult ObtenerEquipoPorId(int id)
        {
            var equipo = equipoService.ObtenerEquipoPorId(id);
            var equipoVM = new EquipoViewModel();
            Mapper.Map(equipo, equipoVM);

            return Ok(equipoVM);
        }

        [HttpPost]
        public IHttpActionResult AgregarEquipo(EquipoViewModel equipoVM)
        {
            Equipo equipoEntity = new Equipo();
            Mapper.Map(equipoVM, equipoEntity);
            equipoService.AgregarEquipo(equipoEntity);
            Mapper.Map(equipoEntity, equipoVM);

            return Created(Url.Link("DefaultApi", new { controller = "Equipo", id = equipoVM.EquipoId }), equipoVM);
        }

        [HttpPut]
        public IHttpActionResult ModificarEquipo(EquipoViewModel equipoVM)
        {
            var equipo = new Equipo();
            Mapper.Map(equipoVM, equipo);
            equipoService.ModificarEquipo(equipo);

            return Ok(equipoVM);
        }

        [HttpDelete]
        public IHttpActionResult EliminarEquipo(int id)
        {
            equipoService.EliminarEquipo(id);

            return Ok();
        }
    }
}
