using Indicadores.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Bitacora
{
    public class Hoja
    {
        public int idhoja { get; set; }
        public int usuarioidusuario { get; set; }
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
        public Usuario usuario { get; set; }

        public virtual ICollection<Registro> registros { get; set; }

    }
}
