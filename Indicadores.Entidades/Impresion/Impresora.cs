using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Impresion
{
    public class Impresora
    {
        public int idimpresora {get; set;}
        public string nombreimpresora { get; set; }
        public string modeloimpresora { get; set; }
        public string serieimpresora { get; set; }
        public string ipimpresora { get; set; }
        public string macimpresora { get; set; }
        public string edificioimpresora { get; set; }
        public string ubicacionimpresora { get; set; }

        public virtual ICollection<ControlToner> cambios { get; set; }
    }
}
