using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Bitacora;
using Indicadores.Web.Models.Bitacora.Registro;
using System.Globalization;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public RegistrosController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Registros/Listar/1
        [HttpGet("[action]/{idhoja}")]
        public async Task<IEnumerable<RegistroViewModel>> Listar([FromRoute] int idhoja)
        {
            var registro = await _context.Registros.Where(u => u.hojaidhoja == idhoja)
                .Include(u => u.descripcion)
                .Include(u => u.hoja)
                .Include(a => a.atribuible)
                .OrderBy(h => h.hinicio)
                .ToListAsync();

            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");

            return registro.Select(r => new RegistroViewModel
            {
                idregistro = r.idregistro,
                idticket = r.idticket,
                idhoja = r.hojaidhoja,
                grupo = r.grupo,
                hinicio = r.hinicio.ToString("t", culture),
                hfin = r.hfin.ToString("t", culture),
                tiempo = (r.hfin - r.hinicio).ToString("t", culture),
                idatribuible = r.atribuibleidatribuible,
                atribuible = r.atribuible.atribcorto,
                iddescripcion = r.descripcioniddescripcion,
                descripcion = r.nomdescripcion,
                solicitante = r.solicitante
            });
        }

        // GET: api/Registros/Export/1
        [HttpGet("[action]/{idhoja}")]
        public async Task<IEnumerable<ExportViewModel>> Export([FromRoute] int idhoja)
        {
            var registro = await _context.Registros.Where(u => u.hojaidhoja == idhoja)
                .Include(u => u.descripcion)
                .Include(u => u.hoja)
                .Include(a => a.atribuible)
                .OrderBy(h => h.hinicio)
                .ToListAsync();

            CultureInfo culture = CultureInfo.CreateSpecificCulture("hr-HR");

            return registro.Select(r => new ExportViewModel
            {
                
                idticket = r.idticket,
                hinicio = r.hinicio.ToString("t", culture),
                hfin = r.hfin.ToString("t", culture),
                atribuible = r.atribuible.atribcorto,
                descripcion = r.nomdescripcion,
                solicitante = r.solicitante
            });
        }


        // POST: api/Registros/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            Registro registro = new Registro
            {
                hojaidhoja = model.idhoja,
                grupo = model.grupo,
                hinicio = DateTime.Parse(model.hinicio),
                hfin = DateTime.Parse(model.hfin),
                atribuibleidatribuible = model.idatribuible,
                descripcioniddescripcion = model.iddescripcion,
                nomdescripcion = model.descripcion,
                solicitante = model.solicitante
            };
            

            _context.Registros.Add(registro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Registros/AddTicket
        [HttpPut("[action]")]
        public async Task<IActionResult> AddTicket([FromBody] AddTicketViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var registro = await _context.Registros
                .FirstOrDefaultAsync(u => u.hojaidhoja == model.idhoja && u.grupo == model.grupo && u.atribuible.atribcorto == "TI");


            registro.idticket = model.idticket;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok();
        }


        private bool RegistroExists(int id)
        {
            return _context.Registros.Any(e => e.idregistro == id);
        }
    }
}
