using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Usuarios.Rol
{
    public class RolViewModel
    {
        public int idrol { get; set; }
        public string nomrol { get; set; }
        public string desrol { get; set; }
        public bool condicion { get; set; }
    }
}
