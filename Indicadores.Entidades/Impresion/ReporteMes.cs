using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Impresion
{
    public class ReporteMes
    {

        public int idreporte { get; set; }
        public int contador109 { get; set; }
        public int contador124 { get; set; }
        public int contador102 { get; set; }
        public int vpbyn { get; set; }
        public int vpcolor { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public int impresoraidimpresora { get; set; }
        
        public Impresora impresora { get; set; }
    }
}
