(function () {
    'use strict';
    angular.module('app')
        .controller('jugadorController', jugadorController);

    jugadorController.$inject = ['jugadorService', 'equipoService', '$stateParams', '$location'];

    function jugadorController(jugadorService, equipoService, $stateParams, $location) {

        var vm = this;
        vm.limpiarCampos = limpiarCampos;
        vm.crearJugador = crearJugador;
        vm.eliminarJugador = eliminarJugador;
        vm.obtenerJugador = obtenerJugador;
        vm.modificarJugador = modificarJugador;
        vm.jugadorSeleccionado = new Jugador();
        vm.equipoSeleccionado = null;
        vm.obtenerEquipo = obtenerEquipo;
        vm.obtenerEquipo();
        vm.noHayCapitan = true;

        // constructor
        function Jugador() {
            return {
                Nombre: "",
                Capitan: false,
                EquipoId: $stateParams.idEquipo
            };
        };

        if ($stateParams.id) {
            vm.obtenerJugador();
        }

        function limpiarCampos() {
            vm.jugadorSeleccionado = null;
        }

        function crearJugador($event) {
            jugadorService.crearJugador(vm.jugadorSeleccionado).$promise
            .then(function (data) {
                $location.url('/campeonato/' + $stateParams.idCampeonato + '/equipo/' + $stateParams.idEquipo);
            });
        }

        function eliminarJugador($event) {
            // TODO: confirm dialog
            jugadorService.eliminarJugador(vm.jugadorSeleccionado.JugadorId).$promise
            .then(function (data) {
                $location.url('/campeonato/' + $stateParams.idCampeonato + '/equipo/' + $stateParams.idEquipo);
            });
        }

        function obtenerJugador() {
            jugadorService.obtenerJugadorPorId($stateParams.id).$promise
            .then(function (jugador) {
                if (jugador) {
                    vm.jugadorSeleccionado = jugador;                    
                }
            });
        }

        function modificarJugador($event) {
            if (vm.jugadorSeleccionado && vm.jugadorSeleccionado.JugadorId) {
                jugadorService.modificarJugador(vm.jugadorSeleccionado).$promise
                .then(function (data) {
                    $location.url('/campeonato/' + $stateParams.idCampeonato + '/equipo/' + $stateParams.idEquipo);
                });
            }
        }

        function obtenerEquipo() {
            equipoService.obtenerEquipoPorId($stateParams.idEquipo).$promise
            .then(function (equipo) {
                if (equipo) {
                    vm.equipoSeleccionado = equipo;
                    vm.noHayCapitan = validarSeleccionarCapitan();
                }
            });
        }

        function validarSeleccionarCapitan() {
            var capitan = vm.equipoSeleccionado.Jugadores.filter(function (j) {
                return j.Capitan && j.JugadorId != vm.jugadorSeleccionado.JugadorId
            });
            
            return capitan.length === 0;
        }

    }
})();
