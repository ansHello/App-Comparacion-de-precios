using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    public class Ubicacion
    {
        public int IdUbicacion { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud
        {
            get; set;
        }
    }
}
