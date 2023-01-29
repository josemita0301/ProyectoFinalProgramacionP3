using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion.Models
{
    [Table("dog")]
    public class Dog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public string Age { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string Email { get; set; }
        public string imageRoute { get; set; }

        public int OldOwnerId { get; set; }

    }


}
