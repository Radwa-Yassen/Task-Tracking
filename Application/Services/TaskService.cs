using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Command;
using Application.ViewModels;
using DLL.Repository;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public void AddTask(AddUpdateTaskCommand taskCommand)
        {
            if (taskCommand != null)
            {
                Domain.Models.Task task = new Domain.Models.Task(taskCommand.Title, taskCommand.Details, taskCommand.UserId, taskCommand.Date);
                _taskRepository.AddTask(task);
            }
        }

        public void DeleteTask(Guid taskId)
        {
            _taskRepository.DeleteTask(taskId);
        }

        public List<TaskViewModel> GetTasksList()
        {
            var list = new List<TaskViewModel>();
            var tasksList = _taskRepository.GetTasksList();
            foreach (var task in tasksList)
            {
                list.Add(new TaskViewModel(task.Id, task.Title, task.Details, task.Date, task.User.Name, task.UserId));
            }

            return list;
        }

        public List<UserViewModel> GetUsersList()
        {
            var list = new List<UserViewModel>();
            var usersList = _taskRepository.GetUsersList();
            foreach (var user in usersList)
            {
                list.Add(new UserViewModel() { Id = user.Id, Name = user.Name });
            }

            return list;
        }

        public void UpdateTask(AddUpdateTaskCommand taskCommand)
        {
            if (taskCommand != null && taskCommand.Id.HasValue)
            {
                Domain.Models.Task task = _taskRepository.GetTaskById(taskCommand.Id.Value);
                task.Title = taskCommand.Title;
                task.Details = taskCommand.Details;
                task.UserId = taskCommand.UserId;
                task.Date = taskCommand.Date;
                _taskRepository.UpdateTask(task);
            }
        }

        public TaskViewModel GetTask(Guid taskId)
        {
            TaskViewModel taskView = null;
            Domain.Models.Task task = _taskRepository.GetTaskById(taskId);
            if (task != null)
            {
                taskView = new TaskViewModel(task.Id, task.Title, task.Details, task.Date, task.User.Name, task.UserId);
            }

            return taskView;
        }
    }
}
