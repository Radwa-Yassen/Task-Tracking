(function () {
    'use strict';
    angular
    .module('app.task')
    .factory('taskService', taskService);

    taskService.$inject = ['$http'];

    function taskService($http) {
        var taskView = {
            addTask: addTask,
            updateTask: updateTask,
            getTask: getTask,
            getTaskList: getTaskList,
            deleteTask: deleteTask,
            getUsersList: getUsersList
        }

        return taskView;

        //addSpace function
        function addTask(addTaskCommand) {
            return $http({
                method: 'POST',
                url: '/api/TaskApi/AddTask',
                data: addTaskCommand
            });
        }

        function updateTask(updateTaskCommand) {
            return $http({
                method: 'POST',
                url: '/api/TaskApi/UpdateTask',
                data: updateTaskCommand
            });
        }

        function getTask(taskId) {
            return $http.get('/api/TaskApi/GetTask', {
                params: { taskId: taskId }
            });
        };

        function deleteTask(taskId) {
            return $http.delete('/api/TaskApi/DeleteTask', {
                params: { taskId: taskId }
            });
        };

        function getTaskList() {
            return $http.get('/api/TaskApi/GetTaskList');
        };

        function getUsersList() {
            return $http.get('/api/TaskApi/GetUsersList');
        };
    }
})();