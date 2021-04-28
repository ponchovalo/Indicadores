using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Descripcion
{
    public class Solucion
    {
        public int idsolucion { get; set; }
        public string nomsolucion { get; set; }

        public int descripcioniddescripcion { get; set; }
        public int tipofallaidtipofalla { get; set; }
        public int catfallaidcatfalla { get; set; }
        public int causafallaidcausafalla { get; set; }
        public int tiposolidtiposol { get; set; }

        public Desc descripcion { get; set; }
        public TipoFalla tipofalla { get; set; }
        public CatFalla catfalla { get; set; }
        public CausaFalla causafalla { get; set; }
        public TipoSol tiposol { get; set; }
    }
}
