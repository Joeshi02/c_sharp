using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ProyectoCoder.Models;
using System.Data;

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
                                        Codigo = Convert.ToInt32(dr["Id"]),
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
                                        Codigo = Convert.ToInt32(dr["Id"]),
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
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = producto.Codigo });
                        comand.Parameters.Add(new SqlParameter("@Descripcion", SqlDbType.NVarChar) { Value = producto.Descripcion });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeCompra", SqlDbType.Float) { Value = producto.PrecioDeCompra });
                        comand.Parameters.Add(new SqlParameter("@PrecioDeVenta", SqlDbType.Float) { Value = producto.PrecioDeVenta });
                        comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = producto.Stock });
                        comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.NVarChar) { Value = producto.IdUsuario });
                        comand.ExecuteNonQuery();
                    }
                }
            }

            public static void EliminarProducto(int IdProducto)
            {
                string query = "DELETE FROM Producto WHERE Id = @Id;";

                using (SqlConnection conexion = new SqlConnection(connectionString))
                {
                    conexion.Open();
                    using (SqlCommand comand = new SqlCommand(query, conexion))
                    {
                        comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = IdProducto });

                        comand.ExecuteNonQuery();
                    }
                }
            }
        }

    }
}
