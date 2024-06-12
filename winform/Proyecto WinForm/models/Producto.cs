using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WinForm.models
{
    public class Producto
    {
        public int id { get; set; }
        public string descripcion {get; set;}
        public double precioDeCompra {get; set;}
        public double precioDeVenta {get; set;}
        public double stock {get; set;}
        public int idUsuario {get; set;}

    }
}
