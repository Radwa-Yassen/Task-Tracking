using DLL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using System.Data.Entity;

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
            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();

        }

        public void DeleteTask(Guid taskId)
        {
            var task = _dbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
            if (task != null)
            {
                _dbContext.Tasks.Remove(task);
                _dbContext.SaveChanges();
            }
        }

        public List<Domain.Models.Task> GetTasksList()
        {
            return _dbContext.Tasks.Include("User").ToList();
        }

        public void UpdateTask(Domain.Models.Task task)
        {
            _dbContext.Entry(task).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public Domain.Models.Task GetTaskById(Guid taskId)
        {
            return _dbContext.Tasks.Where(t => t.Id == taskId).FirstOrDefault();
        }
    }
}
