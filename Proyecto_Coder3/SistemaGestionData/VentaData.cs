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
    public class VentaData
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

        public static List<Venta> ListarVentas()
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
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Comentarios = dr["Comentarios"].ToString(),
                                    IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
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
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = venta.Id });
                    comand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.NVarChar) { Value = venta.Comentarios });
                    comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario }); ;

                    comand.ExecuteNonQuery();
                }
            }
        }

        public static void ActualizarVenta(Venta venta)
        {
            string query = "UPDATE Venta SET comentarios = @Comentarios, IdUsuario= @IdUsuario WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comand = new SqlCommand(query, conexion))
                {
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = venta.Id });
                    comand.Parameters.Add(new SqlParameter("@Comentarios", SqlDbType.NVarChar) { Value = venta.Comentarios });
                    comand.Parameters.Add(new SqlParameter("@IdUsuario", SqlDbType.Int) { Value = venta.IdUsuario });

                    comand.ExecuteNonQuery();
                }
            }
        }

        public static void EliminarVenta(int id)
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

