using Indicadores.Entidades.Descripcion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Bitacora
{
    public class Registro
    {
        public int idregistro { get; set; }
        public int idticket { get; set; }
        public int hojaidhoja { get; set; }
        public int grupo { get; set; }
        public DateTime hinicio { get; set; }
        public DateTime hfin { get; set; }
        public int atribuibleidatribuible { get; set; }
        public int descripcioniddescripcion { get; set; }
        public string nomdescripcion { get; set; }
        public string solicitante { get; set; }
        public Desc descripcion { get; set; }
        public Hoja hoja { get; set; }
        public Atribuible atribuible { get; set; }

    }
}
