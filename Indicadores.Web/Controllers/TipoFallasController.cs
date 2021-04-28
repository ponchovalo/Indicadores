using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.TipoFalla;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoFallasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public TipoFallasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/TipoFallas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoFallaViewModel>> Listar()
        {
            var tipofalla = await _context.TipoFallas.ToListAsync();

            return tipofalla.Select(c => new TipoFallaViewModel
            {
                idtipofalla = c.idtipofalla,
                nomtipofalla = c.nomtipofalla,
                destipofalla = c.destipofalla
            });
        }

        // GET: api/TipoFallas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var tipofalla = await _context.TipoFallas.ToListAsync();

            return tipofalla.Select(c => new SelectViewModel
            {
                idtipofalla = c.idtipofalla,
                nomtipofalla = c.nomtipofalla

            });
        }

        // GET: api/TipoFallas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var tipofalla = await _context.TipoFallas.FindAsync(id);

            if (tipofalla == null)
            {
                return NotFound();
            }

            return Ok(new TipoFallaViewModel
            {
                idtipofalla = tipofalla.idtipofalla,
                nomtipofalla = tipofalla.nomtipofalla,
                destipofalla = tipofalla.destipofalla
            });
        }

        // PUT: api/TipoFallas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtipofalla <= 0)
            {
                return BadRequest();
            }

            var tipofalla = await _context.TipoFallas.FirstOrDefaultAsync(c => c.idtipofalla == model.idtipofalla);

            if (tipofalla == null)
            {
                return NotFound();
            }

            tipofalla.nomtipofalla = model.nomtipofalla;
            tipofalla.destipofalla = model.destipofalla;

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

        // POST: api/TipoFallas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoFalla tipofalla = new TipoFalla
            {
                nomtipofalla = model.nomtipofalla,
                destipofalla = model.destipofalla
            };

            _context.TipoFallas.Add(tipofalla);
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

        // DELETE: api/TipoFallas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipofalla = await _context.TipoFallas.FindAsync(id);
            if (tipofalla == null)
            {
                return NotFound();
            }

            _context.TipoFallas.Remove(tipofalla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(tipofalla);
        }



        private bool TipoFallaExists(int id)
        {
            return _context.TipoFallas.Any(e => e.idtipofalla == id);
        }
    }
}
