using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Desc
{
    public class ActualizarViewModel
    {
        public int iddescripcion { get; set; }
        public int idpartida { get; set; }
        public int iddispositivo { get; set; }
        public int idactividad { get; set; }
        public int idtipoactividad { get; set; }
        public int idactividadadm { get; set; }
        public string descripcion { get; set; }
    }
}
