using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    [Table("Alerta_Precio")]
    public class Alerta_Precio
    {
        [PrimaryKey, AutoIncrement]
        public int IdAlerta { get; set; }

        public decimal PrecioObjetivo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public bool Activa { get; set; }

        public int IdUsuario { get; set; }

        public int IdProducto { get; set; }
    }
}

