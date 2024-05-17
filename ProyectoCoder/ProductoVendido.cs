using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder
{
    internal class ProductoVendido
    {
        private int _Id { get; }
        private int _IdProducto { get; }
        private int _Stock { get; set; }
        private int _IdVenta { get;}

        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            this._Id = id;
            this._IdProducto = idProducto;
            this._Stock = stock;
            this._IdVenta = idVenta;
        }
    }
}
