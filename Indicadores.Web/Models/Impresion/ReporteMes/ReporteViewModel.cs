using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.ReporteMes
{
    public class ReporteViewModel
    {

        public string nombre { get; set; }

        public List<ReporteMesViewModel> registros { get; set; }

    }
}
