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
        private string _descripcion;
        private double _precioDeCompra;
        private double _precioDeVenta;
        private string _categoria;

        public int codigo
        {
            get => _codigo;
            set => _codigo = value;
        }

        public string descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public double precioDeCompra
        {
            get => _precioDeCompra;
            set => _precioDeCompra = value;
        }

        public double precioDeVenta
        {
            get => _precioDeVenta;
            set => _precioDeVenta = value;
        }

        public string categoria
        {
            get => _categoria;
            set => _categoria = value;
        }

        public Product(int codigo, string descripcion, double precioDeCompra, double precioDeVenta, string categoria)
        {
            _codigo = codigo;
            _descripcion = descripcion;
            _precioDeCompra = precioDeCompra;
            _precioDeVenta = precioDeVenta;
            _categoria = categoria;
        }
    }
}
