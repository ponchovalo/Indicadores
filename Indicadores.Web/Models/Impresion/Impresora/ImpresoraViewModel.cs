using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.Impresora
{
    public class ImpresoraViewModel
    {
        public int idimpresora { get; set; }
        public string nombreimpresora { get; set; }
        public string modeloimpresora { get; set; }
        public string serieimpresora { get; set; }
        public string ipimpresora { get; set; }
        public string macimpresora { get; set; }
        public string edificioimpresora { get; set; }
        public string ubicacionimpresora { get; set; }
    }
}
