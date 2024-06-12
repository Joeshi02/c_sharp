using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WinForm.models
{
    public class ProductoVendido
    {
        private int Id;
        private int IdProducto;
        private int Stock;
        private int IdVenta;

        public int id
        {
            get => Id;
            set => Id = value;
        }
        public int idProducto
        {
            get => IdProducto;
            set => IdProducto = value;
        }
        public int stock
        {
            get => Stock;
            set => Stock = value;
        }
        public int idVenta
        {
            get => IdVenta;
            set => IdVenta = value;
        }
        public ProductoVendido(int id, int idProducto, int stock, int idVenta)
        {
            Id = id;
            IdProducto = idProducto;
            Stock = stock;
            IdVenta = idVenta;
        }
        public ProductoVendido()
        {
        }
    }
}
