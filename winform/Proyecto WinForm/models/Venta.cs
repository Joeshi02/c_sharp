using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_WinForm.models
{
    public class Venta
    {
        private int Id;
        private string Comentarios;
        private int IdUsuario;

        public int id
        {
            get => Id;
            set => Id = value;
        }
        public string comentarios
        {
            get => Comentarios;
            set => Comentarios = value;
        }
        public int idUsuario
        {
            get => IdUsuario;
            set => IdUsuario = value;
        }
        public Venta(int id, string comentarios, int idUsuario)
        {
            Id = id;
            Comentarios = comentarios;
            IdUsuario = idUsuario;
        }
        public Venta()
        {
        }
    }
}
