using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command
{
    public class AddUpdateTaskCommand
    {
        public Guid? Id { get; set; }   //has value in update case
        public string Title { get; set; }
        public string Details { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
    }
}
