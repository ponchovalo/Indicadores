using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Bitacora.Registro
{
    public class CrearViewModel
    {
        public int idhoja { get; set; }
        public int grupo { get; set; }
        public string hinicio { get; set; }
        public string hfin { get; set; }
        public int idatribuible { get; set; }
        public int iddescripcion { get; set; }
        public string descripcion { get; set; }
        public string solicitante { get; set; }
    }
}
