using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.Models
{
    public class Producto
    {
        private int _id;
        private string _descripcion;
        private double _precioDeCompra;
        private double _precioDeVenta;
        private double _stock;
        private int _idUsuario;

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Descripcion
        {
            get => _descripcion;
            set => _descripcion = value;
        }

        public double PrecioDeCompra
        {
            get => _precioDeCompra;
            set => _precioDeCompra = value;
        }

        public double PrecioDeVenta
        {
            get => _precioDeVenta;
            set => _precioDeVenta = value;
        }

        public double Stock
        {
            get => _stock;
            set => _stock = value;
        }
        public int IdUsuario
        {
            get => _idUsuario;
            set => _idUsuario = value;
        }

        public Producto(int id, string descripcion, double precioDeCompra, double precioDeVenta, double stock, int idUsuario)
        {
            _id = id;
            _descripcion = descripcion;
            _precioDeCompra = precioDeCompra;
            _precioDeVenta = precioDeVenta;
            _stock = stock;
            _idUsuario = idUsuario;
        }
        public Producto() { }
    }
}
