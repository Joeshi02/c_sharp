using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder
{
    internal class Venta
    {
        private int _Id { get; }
        private string _Comentarios { get; }
        private int _IdUsuario { get; }

        public Venta (int id, string comentarios, int idUsuario)
        {
            this._Id = id;
            this._Comentarios = comentarios;
            this._IdUsuario = idUsuario;
        }
    }
}
