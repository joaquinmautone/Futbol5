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
    public class JugadorController : ApiController
    {
        private readonly IJugadorService jugadorService;

        public JugadorController() : base()
        {

        }

        public JugadorController(IJugadorService jugadorService)
        {
            this.jugadorService = jugadorService;
        }

        [HttpGet]
        public IHttpActionResult ObtenerJugadores()
        {
            var jugadores = jugadorService.ObtenerJugadores();
            var jugadoresVM = new List<JugadorViewModel>();
            Mapper.Map(jugadores, jugadoresVM);

            return Ok(jugadoresVM);
        }

        [HttpGet]
        public IHttpActionResult ObtenerJugadorPorId(int id)
        {
            var jugador = jugadorService.ObtenerJugadorPorId(id);
            var jugadorVM = new JugadorViewModel();
            Mapper.Map(jugador, jugadorVM);

            return Ok(jugadorVM);
        }

        [HttpPost]
        public IHttpActionResult AgregarJugador(JugadorViewModel jugadorVM)
        {
            Jugador jugadorEntity = new Jugador();
            Mapper.Map(jugadorVM, jugadorEntity);
            jugadorService.AgregarJugador(jugadorEntity);
            Mapper.Map(jugadorEntity, jugadorVM);

            return Created(Url.Link("DefaultApi", new { controller = "Jugador", id = jugadorVM.JugadorId }), jugadorVM);
        }

        [HttpPut]
        public IHttpActionResult ModificarJugador(JugadorViewModel jugadorVM)
        {
            var jugador = new Jugador();
            Mapper.Map(jugadorVM, jugador);
            jugadorService.ModificarJugador(jugador);

            return Ok(jugadorVM);
        }

        [HttpDelete]
        public IHttpActionResult EliminarJugador(int id)
        {
            jugadorService.EliminarJugador(id);

            return Ok();
        }
    }
}
