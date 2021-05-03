using Indicadores.Entidades.Impresion;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Usuarios
{
    public class Usuario
    {
        public int idusuario { get; set; }
        public int rolidrol { get; set; }
        public int areaidarea { get; set; }
        public int puestoidpuesto { get; set; }

        public string nomusuario { get; set; }
        public string emailusuario { get; set; }

        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }

        public bool condicion { get; set; }
        public string user { get; set; }
        public Rol rol { get; set; }
        public Area area { get; set; }
        public Puesto puesto { get; set; }


    }
}
