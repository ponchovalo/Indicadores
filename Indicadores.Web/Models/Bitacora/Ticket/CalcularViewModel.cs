using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Ticket
{
    public class CalcularViewModel
    {
        public int idticket { get; set; }
        public int grupo { get; set; }
        public string fechaticket { get; set; }
        public string fechainicio { get; set; }
        public string horainicio { get; set; }
        public string fechacierre { get; set; }
        public string horacierre { get; set; }
        public string duraciontotal { get; set; }
        public string tiempoti { get; set; }
        public string tiempotr { get; set; }
        public string tiempota { get; set; }
        public string tiempoac { get; set; }
        public string tiempoal { get; set; }
        public string tiempoco { get; set; }
        public string tiempomuerto { get; set; }
        public int idactividad { get; set; }
        public string actividad { get; set; }
        public int idtipoactividad { get; set; }
        public int idactadm { get; set; }
        public int idpartida { get; set; }
        public int iddispositivo { get; set; }
        public int iddescripcion { get; set; }
        public string solicitante { get; set; }
    }
}
