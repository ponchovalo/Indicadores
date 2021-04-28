using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Bitacora;
using Indicadores.Web.Models.Bitacora.Ticket;
using System.Globalization;


namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public TicketsController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Tickets/Listar/
        [HttpGet("[action]")]
        public async Task<IEnumerable<ListarViewModel>> Listar()
        {

            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");
            CultureInfo cultureEs = CultureInfo.CreateSpecificCulture("es-ES");
            var ticket = await _context.Tickets
                .Include(a => a.actividad)
                .Include(a => a.tipoactividad)
                .Include(a => a.actividadadm)
                .Include(a => a.tipofalla)
                .Include(a => a.catfalla)
                .Include(d => d.descripcion)
                .Include(a => a.solucion)
                .Include(a => a.causafalla)
                .Include(a => a.dispositivo)
                .Include(a => a.tiposol)
                .Include(a => a.partida)
                .Include(a => a.areafuncional)
                .Include(a => a.ubicacionfuncional)
                .Include(a => a.turno)
                .Include(a => a.usuario.puesto)
                .Include(u => u.usuario).ToListAsync();

            return ticket.Select(d => new ListarViewModel
            {
                idticket = d.idticket,
                fecha = d.fecha.ToString("d", cultureEs),
                actividad = d.actividad.nomactividad,
                ticketsap = d.ticketsap,
                solicitante = d.solicitante,
                
                fechaini = d.fechaini.ToString("d", cultureEs),
                horaini = d.horaini.ToString("t", culture),
                fechafin = d.fechafin.ToString("d", cultureEs),
                horafin = d.horafin.ToString("t", culture),

                tiempota = d.tiempota.ToString(@"hh\:mm", culture),
                tiempotr = d.tiempotr.ToString(@"hh\:mm", culture),
                tiempoac = d.tiempoac.ToString(@"hh\:mm", culture),
                tiempoco = d.tiempoco.ToString(@"hh\:mm", culture),
                tiempoal = d.tiempoal.ToString(@"hh\:mm", culture),
                tiempomuerto = d.tiempomuerto.ToString(@"hh\:mm", culture),
                tiempoti = d.tiempoti.ToString(@"hh\:mm", culture),
                duraciontotal = d.duraciontotal.ToString(@"hh\:mm", culture),

                tipoactividad = d.tipoactividad.nomtipoactividad,
                descripcion = d.descripcion.descripcion,
                actividadadm = d.actividadadm.nomactividadadm,
                tipofalla = d.tipofalla.nomtipofalla,
                catfalla = d.catfalla.nomcatfalla,
                solucion = d.solucion.nomsolucion,
                causafalla = d.causafalla.nomcausafalla,
                dispositivo = d.dispositivo.nomdispositivo,
                tiposol = d.tiposol.nomtiposol,
                herramientas = d.herramientas,
                insumos = d.insumos,
                partidanum = d.partida.nompartida,
                partidanom = d.partida.despartida,
                idareafuncional = d.areafuncional.idtec,
                areafuncional = d.areafuncional.nomarea,
                idubicacionfuncional = d.ubicacionfuncional.idubictec,
                ubicacionfuncional = d.ubicacionfuncional.nomubicacion,
                usuario = d.usuario.nomusuario,
                puesto = d.usuario.puesto.nompuesto,
                turno = d.turno.nomturno,
                horario = d.turno.horario

            });
        }



        // GET: api/Tickets/ListarUser/1
        [HttpGet("[action]/{idusuario}")]
        public async Task<IEnumerable<ListarUserViewModel>> ListarUser([FromRoute] int idusuario)
        {

            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");
            CultureInfo cultureEs = CultureInfo.CreateSpecificCulture("es-ES");
            var ticket = await _context.Tickets
                .Where(u => u.usuarioidusuario == idusuario)
                .Include(d => d.descripcion)
                .Include(u => u.usuario).ToListAsync();

            return ticket.Select(d => new ListarUserViewModel
            {
                idticket = d.idticket,
                fecha = d.fecha.ToString("d", cultureEs),
                ticketsap = d.ticketsap,
                horaini = d.horaini.ToString("t",culture),
                horafin = d.horafin.ToString("t", culture),
                descripcion = d.descripcion.descripcion,
                usuario = d.usuario.nomusuario

            });
        }

        // GET: api/Tickets/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");
            CultureInfo cultureEs = CultureInfo.CreateSpecificCulture("es-ES");
            var ticket = await _context.Tickets
                .Where(a => a.idticket == id)
                .Include(a => a.areafuncional).FirstAsync();

            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(new MostrarViewModel
            {
                idticket = ticket.idticket,
                grupo = ticket.grupo,
                fecha = ticket.fecha.ToString("d", cultureEs),
                idactividad = ticket.actividadidactividad,
                ticketsap = ticket.ticketsap,
                solicitante = ticket.solicitante,
                fechaini = ticket.fechaini.ToString("d", cultureEs),
                horaini = ticket.horaini.ToString("t", culture),
                fechafin = ticket.fechafin.ToString("d", cultureEs),
                horafin = ticket.horafin.ToString("t", culture),
                tiempota = ticket.tiempota.ToString(@"hh\:mm", culture),
                tiempotr = ticket.tiempotr.ToString(@"hh\:mm", culture),
                tiempoac = ticket.tiempoac.ToString(@"hh\:mm", culture),
                tiempoco = ticket.tiempoco.ToString(@"hh\:mm", culture),
                tiempoal = ticket.tiempoal.ToString(@"hh\:mm", culture),
                tiempomuerto = ticket.tiempomuerto.ToString(@"hh\:mm", culture),
                tiempoti = ticket.tiempoti.ToString(@"hh\:mm", culture),
                duraciontotal = ticket.duraciontotal.ToString(@"hh\:mm", culture),
                idtipoactividad = ticket.tipoactividadidtipoactividad,
                iddescripcion = ticket.descripcioniddescripcion,
                idactividadadm = ticket.actividadadmidactividadadm,
                idtipofalla = ticket.tipofallaidtipofalla,
                idcatfalla = ticket.catfallaidcatfalla,
                idsolucion = ticket.solucionidsolucion,
                idcausafalla = ticket.causafallaidcausafalla,
                iddispositivo = ticket.dispositivoiddispositivo,
                idtiposol = ticket.tiposolidtiposol,
                herramientas = ticket.herramientas,
                insumos = ticket.insumos,
                idpartida = ticket.partidaidpartida,
                idareafuncional = ticket.areafuncionalidareafuncional,
                idtec = ticket.areafuncional.idtec,
                idubicacionfuncional = ticket.ubicacionfuncionalidubicacionfuncional,
                iduser = ticket.usuarioidusuario,
                idturno = ticket.turnoidturno,




            });
        }


        // GET: api/Tickets/Calcular
        [HttpGet("[action]/{idh}/{idg}")]
        public async Task<IActionResult> Calcular([FromRoute] int idh, int idg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var registro = await _context.Registros
                .Where(u => u.hojaidhoja == idh && u.grupo == idg)
                .Include(u => u.descripcion)
                .Include(u => u.hoja)
                .Include(a => a.atribuible)
                .OrderBy(h => h.hinicio)
                .ToListAsync();

            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");
            CultureInfo cultureEs = CultureInfo.CreateSpecificCulture("es-ES");

            TimeSpan tiempoti = new TimeSpan();
            TimeSpan tiempotr = new TimeSpan();
            TimeSpan tiempoac = new TimeSpan();
            TimeSpan tiempoco = new TimeSpan();
            TimeSpan tiempoal = new TimeSpan();
            TimeSpan tiempota = new TimeSpan();
            TimeSpan tiempomuerto = new TimeSpan();
            TimeSpan duraciontotal = new TimeSpan();
            DateTime fechaticket = new DateTime();
            DateTime fechainicio = new DateTime();
            DateTime fechacierre = new DateTime();
            DateTime horacierre = new DateTime();
            
            string solicitante = "";

            int idactividad = 0;
            int idtipoactividad = 0;
            int idactadm = 0;
            int idpartida = 0;
            int iddispositivo = 0;
            int iddescripcion = 0;
            int grupo = 0;

            DateTime horainicial = registro.FirstOrDefault().hinicio;
           
            foreach (var item in registro)
            {

                switch (item.atribuible.atribcorto)
                {

                    case "TI":
                        fechaticket = item.hoja.fecha;
                        
                        fechainicio = item.hoja.fecha;
                        fechacierre = item.hoja.fecha;
                        horacierre = item.hfin;
                        tiempoti = (item.hfin - item.hinicio);
                        duraciontotal = (item.hfin - item.hinicio);

                        idactividad = item.descripcion.actividadidactividad;
                        idtipoactividad = item.descripcion.tipoactividadidtipoactividad;
                        idactadm = item.descripcion.actividadadmidactividadadm;
                        idpartida = item.descripcion.partidaidpartida;
                        iddispositivo = item.descripcion.dispositivoiddispositivo;
                        iddescripcion = item.descripcioniddescripcion;
                        
                        grupo = item.grupo;
                        solicitante = item.solicitante;
                        break;
                    case "TR":
                        tiempotr = (item.hfin - item.hinicio) + tiempotr;
                        tiempomuerto = (item.hfin - item.hinicio) + tiempomuerto;
                        break;
                    case "TA":
                        tiempota = (item.hfin - item.hinicio) + tiempota;
                        tiempomuerto = (item.hfin - item.hinicio) + tiempomuerto;
                        break;
                    case "AL":
                        tiempoal = (item.hfin - item.hinicio) + tiempoal;
                        tiempomuerto = (item.hfin - item.hinicio) + tiempomuerto;
                        break;
                    case "AC":
                        tiempoac = (item.hfin - item.hinicio) + tiempoac;
                        tiempomuerto = (item.hfin - item.hinicio) + tiempomuerto;
                        break;
                    case "CO":
                        tiempoco = (item.hfin - item.hinicio) + tiempoco;
                        tiempomuerto = (item.hfin - item.hinicio) + tiempomuerto;
                        break;
                    default:
                        break;
                }
            }

            return Ok(new CalcularViewModel
            {
                grupo = grupo,

                fechaticket = fechaticket.ToString("d", cultureEs),
                
                fechainicio = fechainicio.ToString("d", cultureEs),
                horainicio = horainicial.ToString("t", culture),

                fechacierre = fechacierre.ToString("d", cultureEs),
                horacierre = horacierre.ToString("t", culture),

                duraciontotal = (tiempomuerto + tiempoti).ToString("t", culture),

                tiempoti = tiempoti.ToString("t", culture),
                tiempotr = tiempotr.ToString("t", culture),
                tiempota = tiempota.ToString("t", culture),
                tiempoac = tiempoac.ToString("t", culture),
                tiempoco = tiempoco.ToString("t", culture),
                tiempoal = tiempoal.ToString("t", culture),
                tiempomuerto = tiempomuerto.ToString("t", culture),

                idactividad = idactividad,
                idtipoactividad = idtipoactividad,
                idactadm = idactadm,
                idpartida = idpartida,
                iddispositivo = iddispositivo,
                iddescripcion = iddescripcion,
                solicitante = solicitante,
            });
        }


        // POST: api/Tickets/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Ticket ticket = new Ticket
            {
                hojaidhoja = model.idhoja,
                grupo = model.grupo,
                fecha = DateTime.Parse(model.fecha),
                actividadidactividad = model.idactividad,
                ticketsap = model.ticketsap,
                solicitante = model.solicitante,
                fechaini = DateTime.Parse(model.fechaini),
                horaini = DateTime.Parse(model.horaini),
                fechafin = DateTime.Parse(model.fechafin),
                horafin = DateTime.Parse(model.horafin),
                tiempota = TimeSpan.Parse(model.tiempota),
                tiempotr = TimeSpan.Parse(model.tiempotr),
                tiempoac = TimeSpan.Parse(model.tiempoac),
                tiempoco = TimeSpan.Parse(model.tiempoco),
                tiempoal = TimeSpan.Parse(model.tiempoal),
                tiempomuerto = TimeSpan.Parse(model.tiempomuerto),
                tiempoti = TimeSpan.Parse(model.tiempoti),
                duraciontotal = TimeSpan.Parse(model.duraciontotal),
                tipoactividadidtipoactividad = model.idtipoactividad,
                descripcioniddescripcion = model.iddescripcion,
                actividadadmidactividadadm = model.idactividadadm,
                tipofallaidtipofalla = model.idtipofalla,
                catfallaidcatfalla = model.idcatfalla,
                solucionidsolucion = model.idsolucion,
                causafallaidcausafalla = model.idcausafalla,
                dispositivoiddispositivo = model.iddispositivo,
                tiposolidtiposol = model.idtiposol,
                herramientas = model.herramientas,
                insumos = model.insumos,
                partidaidpartida = model.idpartida,
                areafuncionalidareafuncional = model.idareafuncional,
                ubicacionfuncionalidubicacionfuncional = model.idubicacionfuncional,
                usuarioidusuario = model.idusuario,
                turnoidturno = model.idturno

                

            };

            _context.Tickets.Add(ticket);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(ticket.idticket);
        }

        private bool TicketExists(int id)
        {
            return _context.Tickets.Any(e => e.idticket == id);
        }
    }
}
