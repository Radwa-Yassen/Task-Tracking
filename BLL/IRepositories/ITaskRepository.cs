using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.Repository
{
    public interface ITaskRepository
    {
        void AddTask(Domain.Models.Task task);
        void UpdateTask(Domain.Models.Task task);
        List<Domain.Models.Task> GetTasksList();
        void DeleteTask(Domain.Models.Task task);
    }
}
