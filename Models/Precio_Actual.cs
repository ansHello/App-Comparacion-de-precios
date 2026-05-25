using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparacionPrecios.Models
{
   
    public class Precio_Actual
    {
       
        public int IdPrecio { get; set; }

        public decimal Precio { get; set; }

        public DateTime FechaRegistro { get; set; }

        public int IdProducto { get; set; }

        public int IdTienda { get; set; }

        public int IdUsuario { get; set; }
    }
}

