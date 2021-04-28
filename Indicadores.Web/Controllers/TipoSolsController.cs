using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.TipoSol;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSolsController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public TipoSolsController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/TipoSols/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TipoSolViewModel>> Listar()
        {
            var tiposol = await _context.TipoSols.ToListAsync();

            return tiposol.Select(c => new TipoSolViewModel
            {
                idtiposol = c.idtiposol,
                nomtiposol = c.nomtiposol,
                destiposol = c.destiposol
            });
        }

        // GET: api/TipoSols/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var tiposol = await _context.TipoSols.ToListAsync();

            return tiposol.Select(c => new SelectViewModel
            {
                idtiposol = c.idtiposol,
                nomtiposol = c.nomtiposol

            });
        }

        // GET: api/TipoSols/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var tiposol = await _context.TipoSols.FindAsync(id);

            if (tiposol == null)
            {
                return NotFound();
            }

            return Ok(new TipoSolViewModel
            {
                idtiposol = tiposol.idtiposol,
                nomtiposol = tiposol.nomtiposol,
                destiposol = tiposol.destiposol
            });
        }

        // PUT: api/TipoSols/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idtiposol <= 0)
            {
                return BadRequest();
            }

            var tiposol = await _context.TipoSols.FirstOrDefaultAsync(c => c.idtiposol == model.idtiposol);

            if (tiposol == null)
            {
                return NotFound();
            }

            tiposol.nomtiposol = model.nomtiposol;
            tiposol.destiposol = model.destiposol;

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

        // POST: api/TipoSols/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TipoSol tiposol = new TipoSol
            {
                nomtiposol = model.nomtiposol,
                destiposol = model.destiposol
            };

            _context.TipoSols.Add(tiposol);
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

            var tiposol = await _context.TipoSols.FindAsync(id);
            if (tiposol == null)
            {
                return NotFound();
            }

            _context.TipoSols.Remove(tiposol);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(tiposol);
        }
        private bool TipoSolExists(int id)
        {
            return _context.TipoSols.Any(e => e.idtiposol == id);
        }
    }
}
