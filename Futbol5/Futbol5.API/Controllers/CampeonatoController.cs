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
    public class CampeonatoController : ApiController
    {
        private readonly ICampeonatoService campeonatoService;

        public CampeonatoController() : base()
        {

        }

        public CampeonatoController(ICampeonatoService campeonatoService)
        {
            this.campeonatoService = campeonatoService;
        }

        [HttpGet]
        public IHttpActionResult ObtenerCampeonatos()
        {
            var campeonatos = campeonatoService.ObtenerCampeonatos();
            var campeonatosVM = new List<CampeonatoViewModel>();
            Mapper.Map(campeonatos, campeonatosVM);

            return Ok(campeonatosVM);
        }

        [HttpGet]
        public IHttpActionResult ObtenerCampeonatoPorId(int id)
        {
            var campeonato = campeonatoService.ObtenerCampeonatoPorId(id);
            var campeonatoVM = new CampeonatoViewModel();
            Mapper.Map(campeonato, campeonatoVM);

            return Ok(campeonatoVM);
        }

        [HttpPost]
        public IHttpActionResult AgregarCampeonato(CampeonatoViewModel campeonatoVM)
        {
            Campeonato campeonatoEntity = new Campeonato();
            Mapper.Map(campeonatoVM, campeonatoEntity);
            campeonatoService.AgregarCampeonato(campeonatoEntity);
            Mapper.Map(campeonatoEntity, campeonatoVM);

            return Created(Url.Link("DefaultApi", new { controller = "Campeonato", id = campeonatoVM.CampeonatoId }), campeonatoVM);
        }

        [HttpPut]
        public IHttpActionResult ModificarCampeonato(CampeonatoViewModel campeonatoVM)
        {
            var campeonato = new Campeonato();
            Mapper.Map(campeonatoVM, campeonato);
            campeonatoService.ModificarCampeonato(campeonato);

            return Ok(campeonatoVM);
        }

        [HttpDelete]
        public IHttpActionResult EliminarCampeonato(int id)
        {
            campeonatoService.EliminarCampeonato(id);

            return Ok();
        }
    }
}
