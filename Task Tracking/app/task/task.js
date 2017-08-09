(function () {
    'use strict';

    angular
        .module('app.task')
        .controller('taskController', taskController);

    taskController.$inject = ['$state', '$scope', '$rootScope', 'taskService'];

    function taskController($state, $scope, $rootScope, taskService) {

        var taskCntrl = this;

        taskCntrl.taskList = [];
        taskCntrl.selectedTaskId = null;
        taskCntrl.deleteTask = deleteTask;

        function init() {
            taskService.getTaskList().then(getTaskListSucceeded, getTaskListFaild);
        }

        init();

        function getTaskListSucceeded(result) {
            if (result && result.data) {
                taskCntrl.taskList = result.data;
            }
            else {
                console.log('faild to get task List');
            }
        }

        function getTaskListFaild(err) {
            console.log('faild to get task List');
        }

        function deleteTask(taskId) {
            taskCntrl.selectedTaskId = taskId;
            taskService.deleteTask(taskCntrl.selectedTaskId).then(deleteTaskSucceeded, deleteTaskFaild);
        }

        function deleteTaskSucceeded(result) {
            for (var i = 0; i < taskCntrl.taskList.length; i++) {
                if (taskCntrl.taskList[i].Id == taskCntrl.selectedTaskId) {
                    taskCntrl.taskList.splice(i, 1);
                    break;
                }
            }
        }

        function deleteTaskFaild() {
            console.log('faild to delete task List');
        }

    }
})();
