using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder
{
    public class Product
    {
        private int _codigo;
        private string _description;
        private double _precioDeCompra;
        private double _precioDeVenta;
        private string _categoria; 

        public Product()
        {
            _codigo = 0;
            _description = string.Empty;
            _precioDeCompra= 0;
            _precioDeVenta = 0;
            _categoria= string.Empty
        }
    }
}
