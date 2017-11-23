(function () {
    'use strict';
    angular.module('app').factory('campeonatoService', campeonatoService);
    
    campeonatoService.$inject = ['$resource', 'serviceHelper'];

    function campeonatoService ($resource, serviceHelper) {

        var service = {
            crearCampeonato,
            eliminarCampeonato,
            modificarCampeonato,
            obtenerCampeonatoPorId,
            obtenerCampeonatos
        };

        var campeonato = serviceHelper.Campeonato;

        function crearCampeonato (data) {
            return campeonato.crearCampeonato(data);
        };

        function eliminarCampeonato (id) {
            return campeonato.eliminarCampeonato({ campeonatoId: id });
        };

        function modificarCampeonato (data) {
            return campeonato.modificarCampeonato(data);
        };

        function obtenerCampeonatoPorId (id) {
            return campeonato.obtenerCampeonatoPorId({ id: id });
        };

        function obtenerCampeonatos() {
            return campeonato.obtenerCampeonatos();
        };

        return service;
    };
})();