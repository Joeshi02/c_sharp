using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class ProductoBussiness
    {
        public static List<Producto> ObtenerProducto(int id)
        {
            return ProductoData.ObtenerProducto(id);
        }
        public static List<Producto> ListarProductos()
        {
            return ProductoData.ListarProductos();
        }
        public static void CrearProducto(Producto producto)
        {
            ProductoData.CrearProducto(producto);
        }
        public static void ActualizarProducto(Producto producto)
        {
            ProductoData.ActualizarProducto(producto);
        }
        public static void EliminarProducto(int id)
        {
            ProductoData.EliminarProducto(id);
        }
    }
}
