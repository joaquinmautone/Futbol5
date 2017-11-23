(function () {
    'use strict';

    var API_URL = "http://localhost:64111/";

    angular.module("app").factory('serviceHelper', ['$http', '$resource', function ($http, $resource) {
        var baseUrl = API_URL;
        var buildUrl = function (resourceUrl) {
            return baseUrl + resourceUrl;
        };

        var addRequestHeader = function (key, value) {

        };

        return {
            AuthorizationToken: $resource(buildUrl("Token"), null,
            {
                requestToken: { method: 'POST', headers: { "Content-Type": "application/x-www-form-urlencoded" } }
            }),
            Campeonato: $resource(
                buildUrl('api/Campeonato/:campeonatoId'),
                { campeonatoId: '@id' },
                {
                    obtenerCampeonatos: { url: buildUrl('api/Campeonato/ObtenerCampeonatos'), method: "GET", isArray: true },
                    obtenerCampeonatoPorId: { url: buildUrl('api/Campeonato/ObtenerCampeonatoPorId/:campeonatoId'), method: 'GET' },
                    crearCampeonato: { url: buildUrl('api/Campeonato/AgregarCampeonato'), method: "POST" },
                    modificarCampeonato: { url: buildUrl('api/Campeonato/ModificarCampeonato'), method: "PUT"  },
                    eliminarCampeonato: { url: buildUrl('api/Campeonato/EliminarCampeonato'), method: "DELETE" }
                }
                ),
            Equipo: $resource(
                buildUrl('api/Equipo/:equipoId'),
                { equipoId: '@EquipoId' },
                {
                    obtenerEquipos: { url: buildUrl('api/Equipo/ObtenerEquipos'), method: "GET", isArray: true },
                    obtenerEquipoPorId: { url: buildUrl('api/Equipo/ObtenerEquipoPorId/:equipoId'), method: 'GET' },
                    crearEquipo: { url: buildUrl('api/Equipo/AgregarEquipo'), method: "POST" },
                    modificarEquipo: { url: buildUrl('api/Equipo/ModificarEquipo'), method: "PUT" },
                    eliminarEquipo: { url: buildUrl('api/Equipo/EliminarEquipo'), method: "DELETE" }
                }),
            Jugador: $resource(
                buildUrl('api/Jugador/:jugadorId'),
                { jugadorId: '@JugadorId' },
                {
                    obtenerJugadores: { url: buildUrl('api/Jugador/ObtenerJugadores'), method: "GET", isArray: true },
                    obtenerJugadorPorId: { url: buildUrl('api/Jugador/ObtenerJugadorPorId/:jugadorId'), method: 'GET' },
                    crearJugador: { url: buildUrl('api/Jugador/AgregarJugador'), method: "POST" },
                    modificarJugador: { url: buildUrl('api/Jugador/ModificarJugador'), method: "PUT" },
                    eliminarJugador: { url: buildUrl('api/Jugador/EliminarJugador'), method: "DELETE" }
                })
        };
    }]);
})();