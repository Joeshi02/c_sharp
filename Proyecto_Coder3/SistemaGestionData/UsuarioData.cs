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
    public class UsuarioData
    {
        
          private static string connectionString = "Server=.; Database=SistemaGestion; Trusted_Connection=True;";

        public static Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = null;
            var query = "SELECT Id, Nombre, Apellido, Contraseña AS Password, Mail, NombreUsuario FROM Usuario WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comand = new SqlCommand(query, conexion))
                {
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    using (SqlDataReader dr = comand.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario
                            (
                                Convert.ToInt32(dr["Id"]),
                                dr["Nombre"].ToString(),
                                dr["Apellido"].ToString(),
                                dr["Password"].ToString(), 
                                dr["Mail"].ToString(),
                                dr["NombreUsuario"].ToString()
                            );
                        }
                    }
                }
            }

            return usuario;
        }


        public static List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            var query = "SELECT Id, Nombre, Apellido,  Contraseña AS Password, Mail, NombreUsuario FROM Usuario";

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
                                    Id = Convert.ToInt32(dr["Id"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    Apellido = dr["Apellido"].ToString(),
                                    Mail = dr["Mail"].ToString(),
                                    Password = dr["Password"].ToString(),
                                    NombreUsuario = dr["NombreUsuario"].ToString()
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
                    comand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = usuario.Nombre });
                    comand.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = usuario.Apellido });
                    comand.Parameters.Add(new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = usuario.Mail });
                    comand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = usuario.Password });
                    comand.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.NVarChar) { Value = usuario.NombreUsuario });
                    comand.ExecuteNonQuery();
                }
            }
        }
        public static void ActualizarUsuario(Usuario usuario)
        {
            string query = "UPDATE Usuario SET nombre = @Nombre, apellido = @Apellido, mail = @Mail, contraseña = @Contraseña, nombreUsuario = @NombreUsuario WHERE Id = @Id;";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                using (SqlCommand comand = new SqlCommand(query, conexion))
                {
                    comand.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = usuario.Id });
                    comand.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar) { Value = usuario.Nombre });
                    comand.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar) { Value = usuario.Apellido });
                    comand.Parameters.Add(new SqlParameter("@Mail", SqlDbType.NVarChar) { Value = usuario.Mail });
                    comand.Parameters.Add(new SqlParameter("@Contraseña", SqlDbType.NVarChar) { Value = usuario.Password });
                    comand.Parameters.Add(new SqlParameter("@NombreUsuario", SqlDbType.NVarChar) { Value = usuario.NombreUsuario });
                    comand.ExecuteNonQuery();
                }
            }
        }
        public static void EliminarUsuario(int id)
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
}
