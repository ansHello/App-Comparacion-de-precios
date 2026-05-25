using System;
using System.Collections.Generic;
using System.Text;

namespace ComparacionPrecios.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string CodigoBarras { get; set; }
        public string Marca { get; set; }
        public string Descripcion { get; set; }
        public int IdCategoria { get; set; }
        public decimal Precio { get; set; }
    }
}
