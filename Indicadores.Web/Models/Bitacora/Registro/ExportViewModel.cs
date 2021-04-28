using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Registro
{
    public class ExportViewModel
    {
        public int idticket { get; set; }
        public string hinicio { get; set; }
        public string hfin { get; set; }
        public string atribuible { get; set; }
        public string descripcion { get; set; }
        public string solicitante { get; set; }
    }
}
