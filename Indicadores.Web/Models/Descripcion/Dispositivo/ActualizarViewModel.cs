using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Dispositivo
{
    public class ActualizarViewModel
    {
        public int iddispositivo { get; set; }
        public int idpartida { get; set; }
        public string nomdispositivo { get; set; }
        public string desdispositivo { get; set; }
    }
}
