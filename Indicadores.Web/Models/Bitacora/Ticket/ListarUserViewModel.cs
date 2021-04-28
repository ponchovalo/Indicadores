using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Ticket
{
    public class ListarUserViewModel
    {
        public int idticket { get; set; }
        public string fecha { get; set; }
        public string ticketsap { get; set; }
        public string horaini { get; set; }
        public string horafin { get; set; }
        public string descripcion { get; set; }
        public string usuario { get; set; }
    }
}
