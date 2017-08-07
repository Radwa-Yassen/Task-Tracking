using Application.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Command;
using Application.ViewModels;

namespace Application.Services
{
    public class TaskService : ITaskService
    {
        public void AddTask(AddUpdateTaskCommand taskCommand)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Guid taskId)
        {
            throw new NotImplementedException();
        }

        public List<TaskViewModel> GetTasksList()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(AddUpdateTaskCommand taskCommand)
        {
            throw new NotImplementedException();
        }
    }
}
