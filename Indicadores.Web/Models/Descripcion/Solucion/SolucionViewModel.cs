using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Solucion
{
    public class SolucionViewModel
    {
        public int idsolucion { get; set; }
        public string solucion { get; set; }
        public int iddescripcion { get; set; }
        public string descripcion { get; set; }
        public int idtipofalla { get; set; }
        public string tipofalla { get; set; }
        public int idcatfalla { get; set; }
        public string catfalla { get; set; }
        public int idcausafalla { get; set; }
        public string causafalla { get; set; }
        public int idtiposol { get; set; }
        public string tiposol { get; set; }

    }
}
