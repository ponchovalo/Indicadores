using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Descripcion.Atribuible
{
    public class AtribuibleViewModel
    {
        public int idatribuible { get; set; }
        public string atribcorto { get; set; }
        public string nomatrib { get; set; }
        public string desatrib { get; set; }
        public bool condicion { get; set; }
    }
}
