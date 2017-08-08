using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class TaskViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime Date { get; set; }

        public string UserName { get; set; }

        public Guid UserId { get; set; }

        public TaskViewModel(Guid id, string title, string details, DateTime datetime, string userName, Guid userId)
        {
            Id = id;
            Title = title;
            Details = details;
            Date = datetime;
            UserName = userName;
            UserId = userId;
        }
    }
}
