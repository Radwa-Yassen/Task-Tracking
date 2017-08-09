(function () {
    'use strict';

    angular
        .module('app.task')
        .controller('taskAddEditController', taskAddEditController);

    taskAddEditController.$inject = ['$state', '$scope', '$rootScope', 'taskService','$stateParams'];

    function taskAddEditController($state, $scope, $rootScope, taskService, $stateParams) {

        var taskAddEditCntrl = this;
        taskAddEditCntrl.task = {};
        taskAddEditCntrl.userList = [];
        taskAddEditCntrl.inEditMode = false;
        taskAddEditCntrl.submitted = false;
        taskAddEditCntrl.save = save;

        function init() {
            if ($stateParams.taskId) {
                taskAddEditCntrl.inEditMode = true;
                taskService.getTask($stateParams.taskId).then(getTaskSucceeded, getTaskFaild);
            }

            taskService.getUsersList().then(getUsersListSucceeded, getUsersListFaild);
        }
        init();

        function getUsersListSucceeded(result) {
            if (result && result.data) {
                taskAddEditCntrl.userList = result.data;
            }
            else {
                console.log('faild to get users list');
            }
        }

        function getUsersListFaild() {
            console.log('faild to get users list');
        }

        function getTaskSucceeded(result) {
            if (result && result.data) {
                taskAddEditCntrl.task = result.data;
            }
            else {
                console.log('faild to get task');
            }
        }

        function getTaskFaild(err) {
            console.log('faild to get task');
        }

        function save() {
            taskAddEditCntrl.submitted = true;
            if (taskAddEditCntrl.inEditMode) {
                taskService.updateTask(taskAddEditCntrl.task).then(saveTaskSucceeded, updateTaskFaild);
            }
            else {
                taskService.addTask(taskAddEditCntrl.task).then(saveTaskSucceeded, addTaskFaild);
            }
        }

        function saveTaskSucceeded(result) {
            $state.go('task.list');
        }

        function updateTaskFaild() {
            console.log('faild to update task List');
        }

        function addTaskFaild() {
            console.log('faild to update task List');
        }

        function cancel() {
            $state.go('task.list');
        }
    }
})();
