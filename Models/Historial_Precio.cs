using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    
    public class Historial_Precio
    {
       
        public int IdHistorial { get; set; }

        public decimal Precio { get; set; }

        public DateTime Fecha { get; set; }

        public int IdProducto { get; set; }

        public int IdTienda { get; set; }
    }

}
