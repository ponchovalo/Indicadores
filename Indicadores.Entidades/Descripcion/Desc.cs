using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Descripcion
{
    public class Desc
    {
        public int iddescripcion { get; set; }
        public int partidaidpartida { get; set; }
        public int dispositivoiddispositivo { get; set; }
        public int actividadidactividad { get; set; }
        public int tipoactividadidtipoactividad { get; set; }
        public int actividadadmidactividadadm { get; set; }

        public string descripcion { get; set; }

        public Partida partida { get; set; }
        public Dispositivo dispositivo { get; set; }
        public Actividad actividad { get; set; }
        public TipoActividad tipoactividad { get; set; }
        public ActividadAdm actividadadm { get; set; }




    }
}
