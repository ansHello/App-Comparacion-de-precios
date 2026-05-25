using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    public class Tienda
    {
        public int IdTienda { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public int IdUbicacion { get; set; }
    }
}
