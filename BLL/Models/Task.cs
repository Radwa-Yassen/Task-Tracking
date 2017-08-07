using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLL.Models
{
    [Table("Task")]
    public class Task
    {
        public Guid Id { get; set; }

        [MaxLength(199)]
        public string Title { get; set; }

        [MaxLength(499)]
        public string Details { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public Task(string title, string details,Guid userId)
        {
            Id = Guid.NewGuid();
            Title = title;
            Details = details;
            UserId = userId;
        }

        public Task()
        {

        }
    }
}
