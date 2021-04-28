using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Almacen.Insumo
{
    public class ActualizarViewModel
    {
        public int idinsumo { get; set; }
        public int idcategoria { get; set; }
        public string nominsumo { get; set; }
        public string desinsumo { get; set; }
    }
}
