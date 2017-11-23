(function () {
    'use strict';
    angular.module('app').controller('dashboardController', dashboardController);

    dashboardController.$inject = ['campeonatoService', '$stateParams'];

    function dashboardController(campeonatoService, $stateParams) {
        var vm = this;
        vm.campeonatos = obtenerCampeonatos();

        function obtenerCampeonatos() {
            campeonatoService.obtenerCampeonatos().$promise
            .then(function (data) {
                return vm.campeonatos = data;
            });
        }
    };

})();

