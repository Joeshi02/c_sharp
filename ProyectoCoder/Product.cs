using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder
{
    public class Product
    {
        private int _codigo { get; set; }
        private string _description { get; set; }
        private double _precioDeCompra {get; set;}
        private double _precioDeVenta {get; set;}
        private string _categoria {get; set;}

        public Product(int codigo, string description, double precioDeCompra, double precioDeVenta, string categoria )
        {
            this._codigo = codigo;
            this._description = description;
            this._precioDeCompra= precioDeCompra;
            this._precioDeVenta = precioDeVenta;
            this._categoria = categoria;
        }
       
    }
}
