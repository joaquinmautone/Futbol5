(function () {
    'use strict';
    angular.module('app').factory('equipoService', equipoService);

    equipoService.$inject = ['$resource', 'serviceHelper'];

    function equipoService($resource, serviceHelper) {

        var service = {
            crearEquipo,
            eliminarEquipo,
            modificarEquipo,
            obtenerEquipoPorId,
            obtenerEquipos
        };

        var equipo = serviceHelper.Equipo;

        function crearEquipo(data) {
            return equipo.crearEquipo(data);
        };

        function eliminarEquipo(id) {
            return equipo.eliminarEquipo({ equipoId: id });
        };

        function modificarEquipo(data) {
            return equipo.modificarEquipo(data);
        };

        function obtenerEquipoPorId(id) {
            return equipo.obtenerEquipoPorId({ id: id });
        };

        function obtenerEquipos() {
            return equipo.obtenerEquipos();
        };

        return service;
    };
})();