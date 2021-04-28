using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Hoja
{
    public class HojaViewModel
    {
        public int idhoja { get; set; }
        public int idusuario { get; set; }
        public string usuario { get; set; }
        public string fecha { get; set; } 
        public bool estado { get; set; }

    }
}
