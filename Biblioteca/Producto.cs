using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }
        public int Stock { get; set; }
        public string Proveedor { get; set; }
        
        public Producto(string descripcion, double precio, double costo, int stock, string proveedor)
        {
            this.Id = 1;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Costo = costo;
            this.Stock = stock;
            this.Proveedor = proveedor;

        }

        public void CrearProducto()
        {

        }
        

    }
}
