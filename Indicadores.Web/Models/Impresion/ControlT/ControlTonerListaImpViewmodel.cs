﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Impresion.ControlT
{
    public class ControlTonerListaImpViewmodel
    {
        public int idcontrol { get; set; }
        public DateTime fecha { get; set; }
        public int idimpresora { get; set; }
        public string usuario { get; set; }
        public int idusuario { get; set; }
        public string toner { get; set; }
        public int contador109 { get; set; }
        public int contador124 { get; set; }
        public int contador102 { get; set; } 
    }
}
