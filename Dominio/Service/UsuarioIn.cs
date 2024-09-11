using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Service
{
    public class UsuarioIn
    {
        public string Nombre { get; set; } = null;
        public string Apellido { get; set; } = null;
        public int Edad { get; set; }
        public string Correo { get; set; } = null;
        public string Hobbies { get; set; } = null;

    }
}
