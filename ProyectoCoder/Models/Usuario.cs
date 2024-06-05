using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.Models
{
    public class Usuario
    {
        private int _Id;
        private string _Nombre;
        private string _Apellido;
        private string _Password;
        private string _Mail;

        public int id
        {
            get => _Id;
            set => _Id = value;
        }
        public string nombre
        {
            get => _Nombre;
            set => _Nombre = value;
        }
        public string apellido
        {
            get => _Apellido;
            set => _Apellido = value;

        }
        public string password
        {
            get => _Password;
            set => _Password = value;

        }
        public string mail
        {
            get => _Mail;
            set => _Mail = value;

        }
        public Usuario(int id, string nombre, string apellido, string password, string mail)
        {
            _Id = id;
            _Nombre = nombre;
            _Apellido = apellido;
            _Password = password;
            _Mail = mail;
        }
    }
}
