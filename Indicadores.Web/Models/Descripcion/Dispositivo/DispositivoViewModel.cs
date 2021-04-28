using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Administracion.Dispositivo
{
    public class DispositivoViewModel
    {
        public int iddispositivo { get; set; }
        public int idpartida { get; set; }
        public string partida { get; set; }
        public string nomdispositivo { get; set; }
        public string desdispositivo { get; set; }

    }
}
