using Indicadores.Entidades.Descripcion;
using Indicadores.Entidades.Horario;
using Indicadores.Entidades.Ubicacion;
using Indicadores.Entidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Indicadores.Entidades.Bitacora
{
    public class Ticket
    {
        public int idticket { get; set; }

        public int hojaidhoja { get; set; }
        public int grupo { get; set; }
        public DateTime fecha { get; set; }
        public int actividadidactividad { get; set; }
        public string ticketsap { get; set; }
        public string solicitante { get; set; }
        public DateTime fechaini { get; set; }
        public DateTime horaini { get; set; }
        public DateTime fechafin { get; set; }
        public DateTime horafin { get; set; }

        public TimeSpan tiempota { get; set; }
        public TimeSpan tiempotr { get; set; }
        public TimeSpan tiempoac { get; set; }
        public TimeSpan tiempoco { get; set; }
        public TimeSpan tiempoal { get; set; }
        public TimeSpan tiempomuerto { get; set; }
        public TimeSpan tiempoti { get; set; }
        public TimeSpan duraciontotal { get; set; }
        public int tipoactividadidtipoactividad { get; set; }
        public int descripcioniddescripcion { get; set; }
        public int actividadadmidactividadadm { get; set; }
        public int tipofallaidtipofalla { get; set; }
        public int catfallaidcatfalla { get; set; }
        public int solucionidsolucion { get; set; }
        public int causafallaidcausafalla { get; set; }
        public int dispositivoiddispositivo { get; set; }
        public int tiposolidtiposol { get; set; }
        public string herramientas { get; set; }
        public string insumos { get; set; }
        public int partidaidpartida { get; set; }
        public int areafuncionalidareafuncional { get; set; }
        public int ubicacionfuncionalidubicacionfuncional { get; set; }
        public int usuarioidusuario { get; set; }
        public int turnoidturno { get; set; }

        public Actividad actividad { get; set; }
        public TipoActividad tipoactividad { get; set; }
        public Desc descripcion { get; set; }
        public ActividadAdm actividadadm { get; set; }
        public TipoFalla tipofalla { get; set; }
        public CatFalla catfalla { get; set; }
        public Solucion solucion { get; set; }
        public CausaFalla causafalla { get; set; }
        public Dispositivo dispositivo { get; set; }
        public TipoSol tiposol { get; set; }
        public Partida partida { get; set; }
        public AreaFuncional areafuncional { get; set; }
        public UbicacionFuncional ubicacionfuncional { get; set; }
        public Usuario usuario { get; set; }
        public Turno turno { get; set; }

    }
}
