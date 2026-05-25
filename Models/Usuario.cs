using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    [Table("Usuario")]
    public class Usuario 

    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Cedula { get; set; }

        [MaxLength(50)]
        public string Nombre { get; set; }

        [MaxLength(50)]
        public string Apellido { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Rol { get; set; }

    }
}
