(function () {
    'use strict';
    angular.module('app')
        .controller('equipoController', equipoController);

    equipoController.$inject = ['equipoService', '$stateParams', '$location'];

    function equipoController(equipoService, $stateParams, $location) {

        var vm = this;
        vm.limpiarCampos = limpiarCampos;
        vm.crearEquipo = crearEquipo;
        vm.eliminarEquipo = eliminarEquipo;
        vm.obtenerEquipo = obtenerEquipo;
        vm.modificarEquipo = modificarEquipo;
        vm.idCampeonato = $stateParams.idCampeonato;
        vm.equipoSeleccionado = new Equipo();
        
        // constructor
        function Equipo() {
            return {
                Nombre: "",
                Jugadores: null,
                CampeonatoId: vm.idCampeonato
            };
        };

        if ($stateParams.id) {
            vm.obtenerEquipo();
        }

        function limpiarCampos() {
            vm.equipoSeleccionado = null;
        }

        function crearEquipo($event) {
            equipoService.crearEquipo(vm.equipoSeleccionado).$promise
            .then(function (data) {
                $location.url('/campeonato/' + vm.idCampeonato);
            });
        }

        function eliminarEquipo($event) {
            // TODO: confirm dialog
            equipoService.eliminarEquipo(vm.equipoSeleccionado.EquipoId).$promise
            .then(function (data) {
                $location.url('/campeonato/' + vm.idCampeonato);
            });
        }

        function obtenerEquipo() {
            equipoService.obtenerEquipoPorId($stateParams.id).$promise
            .then(function (equipo) {
                if (equipo) {
                    vm.equipoSeleccionado = equipo;
                }
            });
        }

        function modificarEquipo($event) {
            if (vm.equipoSeleccionado && vm.equipoSeleccionado.EquipoId) {
                equipoService.modificarEquipo(vm.equipoSeleccionado).$promise
                .then(function (data) {
                    $location.url('/campeonato/' + vm.idCampeonato);
                });
            }
        }
    }
})();
