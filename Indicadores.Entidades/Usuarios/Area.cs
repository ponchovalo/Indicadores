using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Usuarios
{
    public class Area
    {
        public int idarea { get; set; }
        public string nomarea { get; set; }
        public string desarea { get; set; }
        public ICollection<Usuario> usuarios { get; set; }
        public virtual ICollection<Puesto> puestos { get; set; }
    }
}
