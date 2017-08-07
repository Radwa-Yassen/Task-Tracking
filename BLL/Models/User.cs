using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    [Table("User")]
    public class User
    {
        public Guid Id { get; set; }

        [MaxLength(199)]
        public string Name { get; set; }

        public User(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public User()
        {

        }
    }
}
