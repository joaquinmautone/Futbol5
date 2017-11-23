using AutoMapper;   
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Futbol5.Entities;
using Futbol5.API.ViewModels;

namespace Futbol5.API
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                // entities to vm
                mapper.CreateMap<Campeonato, CampeonatoViewModel>();
                mapper.CreateMap<Equipo, EquipoViewModel>();
                mapper.CreateMap<Jugador, JugadorViewModel>();

                // vm to entities
                mapper.CreateMap<CampeonatoViewModel, Campeonato>()
                    .ForMember(c => c.Equipos, vm => vm.Ignore());
                mapper.CreateMap<EquipoViewModel, Equipo>()
                    .ForMember(e => e.Jugadores, vm => vm.Ignore());
                mapper.CreateMap<JugadorViewModel, Jugador>();
            });    
        }
    }
}