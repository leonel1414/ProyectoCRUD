using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca1
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; }

        public Producto(int id, string descripcion, double precio, double costo, int stock, string proveedor)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Costo = costo;
            this.Stock = stock;
            this.Proveedor = proveedor;
        }
    }
}
