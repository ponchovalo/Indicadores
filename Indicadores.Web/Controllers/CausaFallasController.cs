using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.CausaFalla;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausaFallasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public CausaFallasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/CatFallas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CausaFallaViewModel>> Listar()
        {
            var causafalla = await _context.CausaFallas.ToListAsync();

            return causafalla.Select(c => new CausaFallaViewModel
            {
                idcausafalla = c.idcausafalla,
                nomcausafalla = c.nomcausafalla,
                descausafalla = c.descausafalla
            });
        }

        // GET: api/CatFallas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var causafalla = await _context.CausaFallas.ToListAsync();

            return causafalla.Select(c => new SelectViewModel
            {
                idcausafalla = c.idcausafalla,
                nomcausafalla = c.nomcausafalla

            });
        }

        // GET: api/CausaFallas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var causafalla = await _context.CausaFallas.FindAsync(id);

            if (causafalla == null)
            {
                return NotFound();
            }

            return Ok(new CausaFallaViewModel
            {
                idcausafalla = causafalla.idcausafalla,
                nomcausafalla = causafalla.nomcausafalla,
                descausafalla = causafalla.descausafalla
            });
        }

        // PUT: api/CausaFallas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcausafalla <= 0)
            {
                return BadRequest();
            }

            var causafalla = await _context.CausaFallas.FirstOrDefaultAsync(c => c.idcausafalla == model.idcausafalla);

            if (causafalla == null)
            {
                return NotFound();
            }

            causafalla.nomcausafalla = model.nomcausafalla;
            causafalla.descausafalla = model.descausafalla;

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

        // POST: api/CausaFallas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CausaFalla causafalla = new CausaFalla
            {
                nomcausafalla = model.nomcausafalla,
                descausafalla = model.descausafalla
            };

            _context.CausaFallas.Add(causafalla);
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

        // DELETE: api/CatFallas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var causafalla = await _context.CausaFallas.FindAsync(id);
            if (causafalla == null)
            {
                return NotFound();
            }

            _context.CausaFallas.Remove(causafalla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(causafalla);
        }


        private bool CausaFallaExists(int id)
        {
            return _context.CausaFallas.Any(e => e.idcausafalla == id);
        }
    }
}
