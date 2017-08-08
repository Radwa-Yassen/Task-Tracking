using Application.Command;
using Application.IServices;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Task_Tracking.Api
{
    public class TaskApiController : ApiController
    {
        private ITaskService _taskService;

        public TaskApiController(ITaskService taskService)
        {
            _taskService = taskService;
        }


        #region Public Methods
        [HttpPost]
        public IHttpActionResult AddTask([FromBody] AddUpdateTaskCommand taskCommand)
        {
            _taskService.AddTask(taskCommand);
            return Ok();
        }

        [HttpPost]
        public IHttpActionResult UpdateTask([FromBody] AddUpdateTaskCommand taskCommand)
        {
            _taskService.UpdateTask(taskCommand);
            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteTask(Guid taskId)
        {
            _taskService.DeleteTask(taskId);
            return Ok();
        }

        [HttpGet]
        [ResponseType(typeof(List<TaskViewModel>))]
        public IHttpActionResult GetTaskList()
        {
            var list = _taskService.GetTasksList();
            return Ok(list);
        }

        [HttpGet]
        [ResponseType(typeof(List<UserViewModel>))]
        public IHttpActionResult GetUsersList()
        {
            var list = _taskService.GetUsersList();
            return Ok(list);
        }

        [HttpGet]
        [ResponseType(typeof(TaskViewModel))]
        public IHttpActionResult GetTask(Guid taskId)
        {
            var task = _taskService.GetTask(taskId);
            return Ok(task);
        }

        #endregion

    }
}