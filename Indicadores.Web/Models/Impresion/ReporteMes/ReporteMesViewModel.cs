using Indicadores.Entidades.Impresion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.ReporteMes
{
    public class ReporteMesViewModel
    {
        public int idreporte { get; set; }
        public int contador109 { get; set; }
        public int contador124 { get; set; }
        public int contador102 { get; set; }
        public int vpbyn { get; set; }
        public int vpcolor { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public Indicadores.Entidades.Impresion.Impresora impresora { get; set; }

    }
}
