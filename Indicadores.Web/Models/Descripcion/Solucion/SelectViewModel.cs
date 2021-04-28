using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Solucion
{
    public class SelectViewModel
    {
        public int idsolucion { get; set; }
        public string solucion { get; set; }
        public int idtipofalla { get; set; }
        public int idcatfalla { get; set; }
        public int idcausafalla { get; set; }
        public int idtiposol { get; set; }
    }
}
