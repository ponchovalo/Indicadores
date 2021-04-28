using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Ticket
{
    public class ListarViewModel
    {
        public int idticket { get; set; }
        public string fecha { get; set; }
        public string actividad { get; set; }
        public string ticketsap { get; set; }
        public string solicitante { get; set; }
        public string fechaini { get; set; }
        public string horaini { get; set; }
        public string fechafin { get; set; }
        public string horafin { get; set; }
        public string tiempota { get; set; }
        public string tiempotr { get; set; }
        public string tiempoac { get; set; }
        public string tiempoco { get; set; }
        public string tiempoal { get; set; }
        public string tiempomuerto { get; set; }
        public string tiempoti { get; set; }
        public string duraciontotal { get; set; }
        public string tipoactividad { get; set; }
        public string descripcion { get; set; }
        public string actividadadm { get; set; }
        public string tipofalla { get; set; }
        public string catfalla { get; set; }
        public string solucion { get; set; }
        public string causafalla { get; set; }
        public string dispositivo { get; set; }
        public string tiposol { get; set; }
        public string herramientas { get; set; }
        public string insumos { get; set; }
        public string partidanum { get; set; }
        public string partidanom { get; set; }
        public string idareafuncional { get; set; }
        public string areafuncional { get; set; }
        public string idubicacionfuncional { get; set; }
        public string ubicacionfuncional { get; set; }
        public string usuario { get; set; }
        public string puesto { get; set; }
        public string turno { get; set; }
        public string horario { get; set; }

    }
}
