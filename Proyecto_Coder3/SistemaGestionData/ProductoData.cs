using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData
{
    public class ProductoData
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
                                        id = Convert.ToInt32(dr["Id"]),
                                        descripcion = dr["Descripciones"].ToString(),
                                        precioDeCompra = Convert.ToDouble(dr["Costo"]),
                                        precioDeVenta = Convert.ToDouble(dr["PrecioVenta"]),
                                        stock = Convert.ToDouble(dr["Stock"])
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
                                        id = Convert.ToInt32(dr["Id"]),
                                        descripcion = dr["Descripciones"].ToString(),
                                        precioDeCompra = Convert.ToDouble(dr["Costo"]),
                                        precioDeVenta = Convert.ToDouble(dr["PrecioVenta"]),
                                        stock = Convert.ToDouble(dr["Stock"])
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
                        comand.Parameters.Add(new SqlParameter("@Descripciones", SqlDbType.NVarChar) { Value = producto.descripcion });
                        comand.Parameters.Add(new SqlParameter("@Costo", SqlDbType.Float) { Value = producto.precioDeCompra });
                        comand.Parameters.Add(new SqlParameter("@PrecioVenta", SqlDbType.Float) { Value = producto.precioDeVenta });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = producto.stock });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NVarChar) { Value = producto.idUsuario });
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
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = producto.id });
                        comand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar) { Value = producto.descripcion });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeCompra", SqlDbType.Float) { Value = producto.precioDeCompra });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeVenta", SqlDbType.Float) { Value = producto.precioDeVenta });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = producto.stock });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NVarChar) { Value = producto.idUsuario });
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
    
}