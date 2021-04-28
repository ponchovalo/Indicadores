using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Usuarios
{
    public class Puesto
    {
        public int idpuesto { get; set; }
        public int areaidarea { get; set; }
        public string nompuesto { get; set; }
        public string despuesto { get; set; } 
        public Area area { get; set; }
        public ICollection<Usuario> usuarios { get; set; }
    }
}
