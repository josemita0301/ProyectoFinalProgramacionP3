using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalProgramacion.Models
{
    [Table("user")]

    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [MaxLength(100)]
        public string name { get; set; }

        [MaxLength(100)]
        public string surname { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(200)]
        public string area { get; set; }

        [MaxLength(10)]
        public string phoneNumber { get; set; }

        public string imageRoute { get; set; }
        [Ignore]
        public string UserPlusDesc => $"{UserName}: {Email}";

    }
}
