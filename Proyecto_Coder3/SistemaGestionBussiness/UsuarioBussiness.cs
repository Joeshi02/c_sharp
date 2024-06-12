using SistemaGestionData;
using SistemaGestionEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionBussiness
{
    public class UsuarioBussiness
    {
        public static List<Usuario> ObtenerUsuario(int id)
        {
            return UsuarioData.ObtenerUsuario(id);
        }
        public static List<Usuario> ListarUsuario()
        {
            return UsuarioData.ListarUsuarios();
        }
        public static void CrearUsuario (Usuario usuario)
        {
             UsuarioData.CrearUsuario(usuario);
        }
        public static void ActualizarUsuario(Usuario usuario)
        {
             UsuarioData.ActualizarUsuario(usuario);
        }
        public static void EliminarUsuario(int id)
        {
             UsuarioData.EliminarUsuario(id);
        }
    }
}
