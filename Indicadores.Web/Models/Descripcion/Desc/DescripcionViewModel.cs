using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Desc
{
    public class DescripcionViewModel
    {
        public int iddescripcion { get; set; }
        public int idpartida { get; set; }
        public string partida { get; set; }
        public int iddispositivo { get; set; }
        public  string dispositivo { get; set; }
        public int idactividad { get; set; }
        public string actividad { get; set; }
        public int idtipoactividad { get; set; }
        public string tipoactividad { get; set; }
        public int idactividadadm { get; set; }
        public string actividadadm { get; set; }
        public string descripcion { get; set;  }
    }
}
