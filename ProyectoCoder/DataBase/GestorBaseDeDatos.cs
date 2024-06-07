using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoCoder.Models;
using System.Data;
using System.Net.NetworkInformation;

namespace ProyectoCoder.DataBase
{
    internal class GestorBaseDeDatos
    {
        public static class ProductoData
        {
            private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

            public static List<Producto> ObtenerProducto(int IdProducto)
            {
                List<Producto> lista = new List<Producto>();
                var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto WHERE Id = @IdProducto;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = IdProducto });

                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var producto = new Producto
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Descripcion = dr["Descripciones"].ToString(),
                                        PrecioDeCompra = Convert.ToDouble(dr["Costo"]),
                                        PrecioDeVenta = Convert.ToDouble(dr["PrecioVenta"]),
                                        Stock = Convert.ToDouble(dr["Stock"])
                                    };
                                    lista.Add(producto);
                                }
                            }
                        }
                    }
                }

                return lista;
            }

            public static List<Producto> ListarProductos()
            {
                List<Producto> lista = new List<Producto>();
                var query = "SELECT Id, Descripciones, Costo, PrecioVenta, Stock, IdUsuario FROM Producto";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var producto = new Producto
                                    {
                                        Id = Convert.ToInt32(dr["Id"]),
                                        Descripcion = dr["Descripciones"].ToString(),
                                        PrecioDeCompra = Convert.ToDouble(dr["Costo"]),
                                        PrecioDeVenta = Convert.ToDouble(dr["PrecioVenta"]),
                                        Stock = Convert.ToDouble(dr["Stock"])
                                    };
                                    lista.Add(producto);
                                }
                            }
                        }
                    }
                }
                return lista;
            }

            public static void CrearProducto(Producto producto)
            {
                string query = "INSERT INTO Producto (Descripciones, Costo, PrecioVenta, Stock, IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario);";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.NVarChar) { Value = producto.Descripcion });
                        comand.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Float) { Value = producto.PrecioDeCompra });
                        comand.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.Float) { Value = producto.PrecioDeVenta });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = producto.Stock });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NVarChar) { Value = producto.IdUsuario });
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void ActualizarProducto(Producto producto)
            {
                string query = "UPDATE Producto SET Descripciones = @Descripcion, Costo = @PrecioDeCompra, PrecioVenta = @PrecioDeVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = producto.Id });
                        comand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar) { Value = producto.Descripcion });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeCompra", SqlDbType.Float) { Value = producto.PrecioDeCompra });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeVenta", SqlDbType.Float) { Value = producto.PrecioDeVenta });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = producto.Stock });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NVarChar) { Value = producto.IdUsuario });
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void EliminarProducto(int Id)
            {
                string query = "DELETE FROM Producto WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });

                        comand.ExecuteNonQuery();
                    }
                }
            }
        }
        public static class ProductoVendidoData
        {
            private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

            public static List<ProductoVendido> ObtenerProductoVendido(int IdProducto)
            {
                List<ProductoVendido> lista = new List<ProductoVendido>();
                var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido WHERE IdProducto = @IdProducto;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = IdProducto });

                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var productoVendido = new ProductoVendido
                                    {
                                        id = Convert.ToInt32(dr["Id"]),
                                        idProducto = Convert.ToInt32(dr["IdProducto"]),
                                        stock = Convert.ToInt32(dr["Stock"]),
                                        idVenta = Convert.ToInt32(dr["IdVenta"])
                                    };
                                    lista.Add(productoVendido);
                                }
                            }
                        }
                    }
                }

                return lista;
            }

            public static List<ProductoVendido> ListarProductosVendidos()
            {
                {
                    List<ProductoVendido> lista = new List<ProductoVendido>();
                    var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido";

                    using (SqlConnection conexion = new SqlConnection(connectionString))
                    {
                        conexion.Open();
                        using (SqlCommand comand = new SqlCommand(query, conexion))
                        {
                            using (SqlDataReader dr = comand.ExecuteReader())
                            {
                                if (dr.HasRows)
                                {
                                    while (dr.Read())
                                    {
                                        var producto = new ProductoVendido
                                        {
                                            id = Convert.ToInt32(dr["Id"]),
                                            idProducto = Convert.ToInt32(dr["IdProducto"]),
                                            stock = Convert.ToInt32(dr["Stock"]),
                                            idVenta = Convert.ToInt32(dr["IdVenta"])
                                        };
                                        lista.Add(producto);
                                    }
                                }
                            }
                        }
                    }
                    return lista;
                }
            }

            public static void CrearProductoVendido(ProductoVendido productoVendido)
            {
                string query = "INSERT INTO ProductoVendido (Id, IdProducto, Stock, IdVenta) VALUES (@Id, @IdProducto, @Stock,@IdVenta);";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Float) { Value = productoVendido.id });
                        comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Float) { Value = productoVendido.idProducto });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = productoVendido.stock });
                        comand.Parameters.Add(new SqlParameter("@IdVenta", SqlDbType.Float) { Value = productoVendido.idVenta });
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void ActualizarProductoVendido(ProductoVendido productoVendido)
            {
                string query = "UPDATE ProductoVendido SET Id = @Id, IdProducto = @IdProducto, Stock = @Stock, IdVenta = @IdVenta WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = productoVendido.id });
                        comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = productoVendido.idProducto });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = productoVendido.stock });
                        comand.Parameters.Add(new SqlParameter("@IdVenta", SqlDbType.Int) { Value = productoVendido.idVenta });
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void EliminarProductoVendido(int Id)
            {
                string query = "DELETE FROM ProductoVendido WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = Id });

                        comand.ExecuteNonQuery();
                    }
                }
            }
        }
        public static class UsuarioData
        {
            private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

            public static List<Usuario> ObtenerUsuario(int id)
            {
                List<Usuario> lista = new List<Usuario>();
                var query = "SELECT Id, Nombre, Apellido, Password, Mail, NombreUsuario FROM Usuario WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var usuario = new Usuario
                                    (
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Nombre"].ToString(),
                                        dr["Apellido"].ToString(),
                                        dr["Password"].ToString(),
                                        dr["Mail"].ToString(),
                                        dr["NombreUsuario"].ToString()
                                    );
                                    lista.Add(usuario);
                                }
                            }
                        }
                    }
                }

                return lista;
            }
            public static List<Usuario> ListarUsuarios()
            {
                List<Usuario> lista = new List<Usuario>();
                var query = "SELECT Id, Nombre, Apellido, Password, Mail, NombreUsuario FROM Usuario";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var usuario = new Usuario
                                    {
                                        id = Convert.ToInt32(dr["Id"]),
                                        nombre = dr["Nombre"].ToString(),
                                        apellido = dr["Apellido"].ToString(),
                                        mail = dr["Mail"].ToString(),
                                        password = dr["Password"].ToString(),
                                        nombreUsuario = dr["NombreUsuario"].ToString()
                                    };
                                    lista.Add(usuario);
                                }
                            }
                        }
                    }
                }
                return lista;
            }
            public static void CrearUsuario(Usuario usuario)
            {
                string query = "INSERT INTO Usuario (Nombre, Apellido, Mail, Contraseña, NombreUsuario) VALUES (@Nombre, @Apellido, @Mail, @Contraseña, @NombreUsuario);";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = usuario.nombre });
                        comand.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = usuario.apellido });
                        comand.Parameters.Add(new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = usuario.mail });
                        comand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = usuario.password });
                        comand.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.NVarChar) { Value = usuario.nombreUsuario });
                        comand.ExecuteNonQuery();
                    }
                }
            }
            public static void ActualizarUsuario (Usuario usuario)
            {
                string query = "UPDATE Usuario SET nombre = @Nombre, apellido = @Apellido, mail = @Mail, contraseña = @Contraseña, nombreUsuario = @NombreUsuario WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuario.id });
                        comand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = usuario.nombre });
                        comand.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = usuario.apellido });
                        comand.Parameters.Add(new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = usuario.mail });
                        comand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = usuario.password });
                        comand.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.NVarChar) { Value = usuario.nombreUsuario });
                        comand.ExecuteNonQuery();
                    }
                }
            }
            public static void EliminarUsuario ( int id)
            {
                      
                string query = "DELETE FROM Usuario WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        comand.ExecuteNonQuery();
                    }
                }
            
            }
        }        
        public static class VentaData
        {
            private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

            public static List<Venta> ObtenerVenta(int id)
            {
                List<Venta> lista = new List<Venta>();
                var query = "SELECT Id, Comentarios, IdUsuario FROM Venta WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var venta = new Venta
                                    (
                                        Convert.ToInt32(dr["Id"]),
                                        dr["Comentarios"].ToString(),
                                        Convert.ToInt32(dr["IdUsuario"])
                                    );
                                    lista.Add(venta);
                                }
                            }
                        }
                    }
                }

                return lista;
            }

            public static List <Venta> ListarVentas()
            {
                List<Venta> lista = new List<Venta>();
                var query = "SELECT Id, Comentarios, IdUsuario FROM Venta";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        using (SqlDataReader dr = comand.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                while (dr.Read())
                                {
                                    var venta = new Venta
                                    {
                                        id = Convert.ToInt32(dr["Id"]),
                                        comentarios = dr["Comentarios"].ToString(),
                                        idUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                    };
                                    lista.Add(venta);
                                }
                            }
                        }
                    }
                }
                return lista;
            }

            public static void CrearVenta(Venta venta)
            {
                string query = "INSERT INTO Venta (Id, Comentarios, IdUsuario) VALUES (@Id, @Comentarios, @IdUsuario);";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = venta.id });
                        comand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.NVarChar) { Value = venta.comentarios });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = venta.idUsuario }); ;

                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void ActualizarVenta (Venta venta)
            {
                string query = "UPDATE Venta SET comentarios = @Comentarios, IdUsuario= @IdUsuario WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = venta.id });
                        comand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.NVarChar) { Value = venta.comentarios });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = venta.idUsuario });
                        
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void EliminarVenta (int id)
            {
                string query = "DELETE FROM Venta WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                        comand.ExecuteNonQuery();
                    }
                }
            }
        }
    }   
}

