using ProyectoCoder.DataBase;
using ProyectoCoder.Models;

namespace ProyectoCoder
{
    class Program
    {
        static void Main(string[] args)
        {
            // Obtener un producto por su ID (suponiendo que exista en la base de datos)
            var producto = GestorBaseDeDatos.ProductoData.ObtenerProducto(1);
            if (producto.Count > 0)
            {
                Console.WriteLine("Producto encontrado:");
                Console.WriteLine(producto[0].ToString());
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }

            // Listar todos los productos
            var listaProductos = GestorBaseDeDatos.ProductoData.ListarProductos();
            Console.WriteLine("\nLista de productos:");
            foreach (var prod in listaProductos)
            {
                Console.WriteLine(prod.ToString());
            }

            // Crear un nuevo producto
            //var nuevoProducto = new Producto(101, "remeras negra", 10.5, 20.5,2, 1 );
            //GestorBaseDeDatos.ProductoData.CrearProducto(nuevoProducto);
            //Console.WriteLine("\nNuevo producto creado.");

            // Actualizar el producto recién creado
            //nuevoProducto.PrecioDeVenta = 25.0;
            //GestorBaseDeDatos.ProductoData.ActualizarProducto(nuevoProducto);
            //Console.WriteLine("Producto actualizado.");

            // Eliminar el producto recién creado
            GestorBaseDeDatos.ProductoData.EliminarProducto(101);
            Console.WriteLine("Producto eliminado.");
        }
    }
}
