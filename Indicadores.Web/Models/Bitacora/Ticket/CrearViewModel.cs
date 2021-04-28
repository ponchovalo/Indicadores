using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Ticket
{
    public class CrearViewModel
    {
        
        public int idhoja { get; set; }
        public int grupo { get; set; }
        public string fecha { get; set; }
        public int idactividad { get; set; }
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
        public int idtipoactividad { get; set; }
        public int iddescripcion { get; set; }
        public int idactividadadm { get; set; }
        public int idtipofalla { get; set; }
        public int idcatfalla { get; set; }
        public int idsolucion { get; set; }
        public int idcausafalla { get; set; }
        public int iddispositivo { get; set; }
        public int idtiposol { get; set; }
        public string herramientas { get; set; }
        public string insumos { get; set; }
        public int idpartida { get; set; }
        public int idareafuncional { get; set; }
        public int idubicacionfuncional { get; set; }
        public int idusuario { get; set; }
        public int idturno { get; set; }

    }
}
