using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.ControlT
{
    public class ControlTonerListaImpViewmodel
    {
        public int idcontrol { get; set; }
        public DateTime fecha { get; set; }
        public int idimpresora { get; set; }
        public string usuario { get; set; }
        public int idusuario { get; set; }
    }
}
