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
    public class ProductoVendidoData
    {
        private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

        public static ProductoVendido ObtenerProductoVendido(int IdProducto)
        {
            ProductoVendido productoVendido = null;
            var query = "SELECT Id, IdProducto, Stock, IdVenta FROM ProductoVendido WHERE IdProducto = @IdProducto;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comand = new SqlCommand(query, conexion))
                {
                    comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = IdProducto });

                    using (SqlDataReader dr = comand.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            productoVendido = new ProductoVendido
                            {
                                Id = Convert.ToInt32(dr["Id"]),
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Stock = Convert.ToInt32(dr["Stock"]),
                                IdVenta = Convert.ToInt32(dr["IdVenta"])
                            };
                        }
                    }
                }
            }

            return productoVendido;
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
                                        Id = Convert.ToInt32(dr["Id"]),
                                        IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                        Stock = Convert.ToInt32(dr["Stock"]),
                                        IdVenta = Convert.ToInt32(dr["IdVenta"])
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
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Float) { Value = productoVendido.Id });
                    comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Float) { Value = productoVendido.IdProducto });
                    comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Float) { Value = productoVendido.Stock });
                    comand.Parameters.Add(new SqlParameter("@IdVenta", SqlDbType.Float) { Value = productoVendido.IdVenta });
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
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = productoVendido.Id });
                    comand.Parameters.Add(new SqlParameter("@IdProducto", SqlDbType.Int) { Value = productoVendido.IdProducto });
                    comand.Parameters.Add(new SqlParameter("@Stock", SqlDbType.Int) { Value = productoVendido.Stock });
                    comand.Parameters.Add(new SqlParameter("@IdVenta", SqlDbType.Int) { Value = productoVendido.IdVenta });
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
}
