using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities
{
    public class Usuario
    {
 
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string NombreUsuario { get; set; }
        public Usuario(int id, string nombre, string apellido, string password, string mail, string nombreUsuario)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Mail = mail;
            NombreUsuario = nombreUsuario;
        }

        // Constructor vacío
        public Usuario() { }

    }
}
