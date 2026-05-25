using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    [Table("Valoracion")]
    public class Valoracion
    {
        [PrimaryKey, AutoIncrement]
        public int IdValoracion { get; set; }

        public int Puntuacion { get; set; }

        public string Comentario { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUsuario { get; set; }

        public int IdTienda { get; set; }
    }
}

