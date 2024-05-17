using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder
{
    internal class Usuario
    {
        private int _Id { get; set; }
        private string _Nombre { get; set; }
        private string _Apellido { get; set; }
        private string _Contraseña { get; set; }
        private string _Mail { get; set; }

        public Usuario(int id, string nombre, string apellido, string contraseña, string mail)
        {
            this._Id = id;
            this._Nombre = nombre;
            this._Apellido = apellido;
            this._Contraseña = contraseña;
            this._Mail = mail;
        }
    }
}
