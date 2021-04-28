using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.Actividad;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public ActividadesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Actividades/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ActividadViewModel>> Listar()
        {
            var actividad = await _context.Actividades.ToListAsync();

            return actividad.Select(a => new ActividadViewModel
            {
                idactividad = a.idactividad,
                nomactividad = a.nomactividad,
                desactividad = a.desactividad

            });
        }

        // GET: api/Actividades/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var actividad = await _context.Actividades.ToListAsync();

            return actividad.Select(a => new SelectViewModel
            {
                idactividad = a.idactividad,
                nomactividad = a.nomactividad

            });
        }

        // GET: api/Actividades/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var actividad = await _context.Actividades.FindAsync(id);

            if (actividad == null)
            {
                return NotFound();
            }

            return Ok(new ActividadViewModel
            {
                idactividad = actividad.idactividad,
                nomactividad = actividad.nomactividad,
                desactividad = actividad.desactividad
            });
        }

        // PUT: api/Actividades/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idactividad <= 0)
            {
                return BadRequest();
            }

            var actividad = await _context.Actividades.FirstOrDefaultAsync(c => c.idactividad == model.idactividad);

            if (actividad == null)
            {
                return NotFound();
            }

            actividad.nomactividad = model.nomactividad;
            actividad.desactividad = model.desactividad;

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

        // POST: api/Actividades/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Actividad actividad = new Actividad
            {
                nomactividad = model.nomactividad,
                desactividad = model.desactividad
            };

            _context.Actividades.Add(actividad);
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

        // DELETE: api/Partidas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actividad = await _context.Actividades.FindAsync(id);
            if (actividad == null)
            {
                return NotFound();
            }

            _context.Actividades.Remove(actividad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(actividad);
        }

        private bool ActividadExists(int id)
        {
            return _context.Actividades.Any(e => e.idactividad == id);
        }
    }
}
