(function () {
    'use strict';
    angular.module('app').config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $urlRouterProvider.otherwise('/dashboard');

        $stateProvider
        .state('app', {
            abstract: true,
            templateUrl: 'Views/shared/layouts/layout.html'
        })
        .state('dashboard', {
            parent: 'app',
            url: '/dashboard',
            templateUrl: 'Views/main.html',
            controller: "dashboardController",
            controllerAs: "vm"
        })
        .state('campeonato', {
            parent: 'app',
            url: "/campeonato/{id}",
            templateUrl: "Views/campeonato/campeonato.html",
            controller: "campeonatoController",
            controllerAs: "vm",
            params: { id: null }
        })
        .state('equipo', {
            parent: 'app',
            url: "/campeonato/{idCampeonato}/equipo/{id}",
            templateUrl: "Views/equipo/equipo.html",
            controller: "equipoController",
            controllerAs: "vm",
            params: { id: null }
        })
        .state('jugador', {
            parent: 'app',
            url: "/campeonato/{idCampeonato}/equipo/{idEquipo}/jugador/{id}",
            templateUrl: "Views/jugador/jugador.html",
            controller: "jugadorController",
            controllerAs: "vm",
            params: { id: null }
        })
        // Additional Pages
        .state('404', {
            url: '/404',
            templateUrl: 'views/pages/404.html'
        })
        .state('500', {
            url: '/500',
            templateUrl: 'views/pages/500.html'
        });

        //$httpProvider.defaults.useXDomain = true;
        //delete $httpProvider.defaults.headers.common['X-Requested-With'];
        //$httpProvider.defaults.useXDomain = true;
        //$locationProvider.html5Mode(true);
        //$httpProvider.interceptors.push('authorizationInterceptor');
        //$httpProvider.interceptors.push('httpInterceptor');
    }
})()