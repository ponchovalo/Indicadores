using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Usuarios.Usuario
{
    public class CrearViewModel
    {
        
        public int idrol { get; set; }
        public int idarea { get; set; }
        public int idpuesto { get; set; }

        public string nomusuario { get; set; }
        public string emailusuario { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        
    }
}
