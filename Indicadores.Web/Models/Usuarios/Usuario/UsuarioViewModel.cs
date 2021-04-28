using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Indicadores.Web.Models.Usuarios.Usuario
{
    public class UsuarioViewModel
    {
        public int idusuario { get; set; }
        public int idrol { get; set; }
        public string rol { get; set; }
        public int idarea { get; set; }
        public string area { get; set; }
        public int idpuesto { get; set; }
        public string puesto { get; set; }

        public string nomusuario { get; set; }
        public string emailusuario { get; set; }

        public byte[] password_hash { get; set; }

        public bool condicion { get; set; }
        public string user { get; set; }
    }
}
