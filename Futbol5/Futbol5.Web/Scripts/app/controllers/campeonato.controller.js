(function () {
    'use strict';
    angular.module('app')
        .controller('campeonatoController', campeonatoController);

    campeonatoController.$inject = ['campeonatoService', '$stateParams', '$location'];

    function campeonatoController(campeonatoService, $stateParams, $location) {

        var vm = this;
        vm.limpiarCampos = limpiarCampos;
        vm.crearCampeonato = crearCampeonato;
        vm.eliminarCampeonato = eliminarCampeonato;
        vm.obtenerCampeonato = obtenerCampeonato;
        vm.modificarCampeonato = modificarCampeonato;
        vm.campeonatoSeleccionado = new Campeonato();

        // constructor
        function Campeonato() {
            return {
                Nombre: "",
                FechaDesde: new Date(),
                FechaHasta: new Date(new Date().setMonth(new Date().getMonth() + 1)),
                Equipos: null
            };
        };

        if ($stateParams.id) {
            vm.obtenerCampeonato();
        }

        function limpiarCampos() {
            vm.campeonatoSeleccionado = null;
        }

        function crearCampeonato($event) {
            campeonatoService.crearCampeonato(vm.campeonatoSeleccionado).$promise
            .then(function (data) {
                $location.url('/dashboard');
            });
        }

        function eliminarCampeonato($event) {
            // TODO: confirm dialog
            campeonatoService.eliminarCampeonato(vm.campeonatoSeleccionado.CampeonatoId).$promise
            .then(function (data) {
                $location.url('/dashboard');
            });
        }

        function obtenerCampeonato() {
            campeonatoService.obtenerCampeonatoPorId($stateParams.id).$promise
            .then(function (campeonato) {
                if (campeonato) {
                    vm.campeonatoSeleccionado = campeonato;
                }                
            });
        }

        function modificarCampeonato($event) {
            if (vm.campeonatoSeleccionado && vm.campeonatoSeleccionado.CampeonatoId) {
                campeonatoService.modificarCampeonato(vm.campeonatoSeleccionado).$promise
                .then(function (data) {
                    $location.url('/dashboard');
                });
            }
        }
    }
})();
