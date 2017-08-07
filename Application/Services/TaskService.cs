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
                Domain.Models.Task task = new Domain.Models.Task(taskCommand.Title, taskCommand.Details, taskCommand.UserId);
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
                list.Add(new TaskViewModel(task.Id, task.Title, task.Details, task.Date, task.User.Name));
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
                _taskRepository.UpdateTask(task);
            }
        }
    }
}
