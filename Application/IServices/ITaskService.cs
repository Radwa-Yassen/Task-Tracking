using Application.Command;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ITaskService
    {
        void AddTask(AddUpdateTaskCommand taskCommand);
        void UpdateTask(AddUpdateTaskCommand taskCommand);
        List<TaskViewModel> GetTasksList();
        void DeleteTask(Guid taskId);
    }
}
