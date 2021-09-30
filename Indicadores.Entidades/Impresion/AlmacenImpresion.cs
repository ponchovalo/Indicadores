using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Impresion
{
    public class AlmacenImpresion
    {
        public int id { get; set; }
        public string noparte { get; set; }
        public string paramodelo { get; set; }
        public string descripcion { get; set; }
        public string categoria { get; set; }
        public string vidautil { get; set; }
        public int cantidad { get; set; }
    }
}
