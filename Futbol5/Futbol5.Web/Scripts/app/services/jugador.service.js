(function () {
    'use strict';
    angular.module('app').factory('jugadorService', jugadorService);

    jugadorService.$inject = ['$resource', 'serviceHelper'];

    function jugadorService($resource, serviceHelper) {

        var service = {
            crearJugador,
            eliminarJugador,
            modificarJugador,
            obtenerJugadorPorId,
            obtenerJugadores
        };

        var jugador = serviceHelper.Jugador;

        function crearJugador(data) {
            return jugador.crearJugador(data);
        };

        function eliminarJugador(id) {
            return jugador.eliminarJugador({ jugadorId: id });
        };

        function modificarJugador(data) {
            return jugador.modificarJugador(data);
        };

        function obtenerJugadorPorId(id) {
            return jugador.obtenerJugadorPorId({ id: id });
        };

        function obtenerJugadores() {
            return jugador.obtenerJugadores();
        };

        return service;
    };
})();