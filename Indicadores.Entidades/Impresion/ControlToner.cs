
using Indicadores.Entidades.Impresion;
using Indicadores.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Impresion
{
    public class ControlToner
    {
        public int idcontrol { get; set; }
        public int contador109 { get; set; }
        public int contador124 { get; set; }
        public int contador102 { get; set; }
        public DateTime fecha { get; set; }
        public int impresoraidimpresora { get; set; }
        public Impresora impresora { get; set; }
        public int usuarioidusuario { get; set; }
        public Usuario usuario { get; set; }


    }
}
