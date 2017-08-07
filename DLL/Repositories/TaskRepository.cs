using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace DLL.Repositories
{
    public class TaskRepository : ITaskRepository, IDisposable
    {
        protected ApplicationDbContext _dbContext;

        public TaskRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual void Dispose()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }

        public void AddTask(Domain.Models.Task task)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Domain.Models.Task task)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Models.Task> GetTasksList()
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Domain.Models.Task task)
        {
            throw new NotImplementedException();
        }
    }
}
