using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.TipoActividad;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoActividadesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public TipoActividadesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/TipoActividades/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoActividadViewModel>> Listar()
        {
            var tipoactividad = await _context.TipoActividades.ToListAsync();

            return tipoactividad.Select(t => new TipoActividadViewModel
            {
                idtipoactividad = t.idtipoactividad,
                nomtipoactividad = t.nomtipoactividad,
                destipoactividad = t.destipoactividad

            });
        }

        // GET: api/TipoActividades/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var tipoactividad = await _context.TipoActividades.ToListAsync();

            return tipoactividad.Select(t => new SelectViewModel
            {
                idtipoactividad = t.idtipoactividad,
                nomtipoactividad = t.nomtipoactividad

            });
        }

        // GET: api/TipoActividades/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var tipoactividad = await _context.TipoActividades.FindAsync(id);

            if (tipoactividad == null)
            {
                return NotFound();
            }

            return Ok(new TipoActividadViewModel
            {
                idtipoactividad = tipoactividad.idtipoactividad,
                nomtipoactividad = tipoactividad.nomtipoactividad,
                destipoactividad = tipoactividad.destipoactividad
            });
        }

        // PUT: api/TipoActividades/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtipoactividad <= 0)
            {
                return BadRequest();
            }

            var tipoactividad = await _context.TipoActividades.FirstOrDefaultAsync(c => c.idtipoactividad == model.idtipoactividad);

            if (tipoactividad == null)
            {
                return NotFound();
            }

            tipoactividad.nomtipoactividad = model.nomtipoactividad;
            tipoactividad.destipoactividad = model.destipoactividad;

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

        // POST: api/TipoActividades/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoActividad tipoactividad = new TipoActividad
            {
                nomtipoactividad = model.nomtipoactividad,
                destipoactividad = model.destipoactividad
            };

            _context.TipoActividades.Add(tipoactividad);
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

        // DELETE: api/TipoActividades/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipoactividad = await _context.TipoActividades.FindAsync(id);
            if (tipoactividad == null)
            {
                return NotFound();
            }

            _context.TipoActividades.Remove(tipoactividad);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(tipoactividad);
        }



        private bool TipoActividadExists(int id)
        {
            return _context.TipoActividades.Any(e => e.idtipoactividad == id);
        }
    }
}
