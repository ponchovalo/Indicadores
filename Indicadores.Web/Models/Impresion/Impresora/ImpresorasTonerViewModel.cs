using Indicadores.Entidades.Impresion;
using Indicadores.Web.Models.Impresion.ControlT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.Impresora
{
    public class ImpresorasTonerViewModel
    {
        public int idimpresora { get; set; }
        public string nombreimpresora { get; set; }
        public string modeloimpreosra { get; set; }
        public List<ControlToner> cambios { get; set; }
    }
}
