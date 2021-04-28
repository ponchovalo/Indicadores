using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Usuarios
{
    public class Rol
    {
        public int idrol { get; set; }
        public string nomrol { get; set; }
        public string desrol { get; set; }
        public bool condicion { get; set; }
        public ICollection<Usuario> usuarios { get; set; }
    }
}
