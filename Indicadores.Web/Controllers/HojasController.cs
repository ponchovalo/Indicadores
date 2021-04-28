using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Bitacora;
using Indicadores.Web.Models.Bitacora.Hoja;
using System.Globalization;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HojasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public HojasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Hojas/Listar/1
        [HttpGet("[action]/{iduser}")]
        public async Task<IEnumerable<HojaViewModel>> Listar([FromRoute] int iduser)
        {
            var hoja = await _context.Hojas.Where(u => u.usuarioidusuario == iduser).Include(u => u.usuario).OrderByDescending(h => h.fecha).ToListAsync();

            CultureInfo culture = CultureInfo.CreateSpecificCulture("es-ES");

            return hoja.Select(h => new HojaViewModel
            {
                idhoja = h.idhoja,
                idusuario = h.usuarioidusuario,
                usuario = h.usuario.nomusuario,
                fecha = h.fecha.ToString("d", culture),
                estado = h.estado,
                
            });
        }
        // POST: api/Hojas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fecha1 = model.fecha;
            Hoja hoja = new Hoja
            {
                usuarioidusuario = model.idusuario,
                fecha = DateTime.Parse(fecha1),
                estado = false
            };

            _context.Hojas.Add(hoja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(hoja.idhoja);
        }

        // PUT: api/Hojas/Cerrar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Cerrar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var hoja = await _context.Hojas.FirstOrDefaultAsync(u => u.idhoja == id);

            if (hoja == null)
            {
                return NotFound();
            }

            hoja.estado = true;

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

        // GET: api/Hojas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var hoja = await _context.Hojas.FindAsync(id);

            if (hoja == null)
            {
                return NotFound();
            }

            return Ok(new EstadoViewModel
            {
                idhoja = hoja.idhoja,
                estado = hoja.estado
            });
        }


        // DELETE: api/Hojas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hoja = await _context.Partidas.FindAsync(id);
            if (hoja == null)
            {
                return NotFound();
            }

            _context.Partidas.Remove(hoja);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(hoja);
        }


        private bool HojaExists(int id)
        {
            return _context.Hojas.Any(e => e.idhoja == id);
        }
    }
}
