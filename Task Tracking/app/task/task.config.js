(function () {
    'use strict';

    angular.module('app.task')
   .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
       $urlRouterProvider.otherwise('/list');

       $stateProvider

          .state('task', {
              url: '/',
              templateUrl: '/app/task/index.html',
              controller: ['$state', function ($state) {
                  if ($state.current.name === 'task') {
                      $state.go('task.list');
                  }
              }]
          })

          .state('task.list', {
              url: 'list',
              templateUrl: '/app/task/list.html',
          })

          .state('task.addEdit', {
              url: 'addEdit:taskId',
              templateUrl: '/app/task/AddEdit.html',
          })
   }]);
})();
