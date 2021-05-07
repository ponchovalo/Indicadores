using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.Partida;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public PartidasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Partidas/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<PartidaViewModel>> Listar()
        {
            var partida = await _context.Partidas.ToListAsync();

            return partida.Select(c => new PartidaViewModel
            {
                idpartida = c.idpartida,
                nompartida = c.nompartida,
                despartida = c.despartida
            });
        }

        // GET: api/Partidas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var partida = await _context.Partidas.ToListAsync();

            return partida.Select(c => new SelectViewModel
            {
                idpartida = c.idpartida,
                nompartida = c.nompartida

            });
        }

        // GET: api/Partidas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var partida = await _context.Partidas.FindAsync(id);

            if (partida == null)
            {
                return NotFound();
            }

            return Ok (new PartidaViewModel { 
                idpartida = partida.idpartida,
                nompartida = partida.nompartida,
                despartida = partida.despartida
            });
        }

        // PUT: api/Partidas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idpartida <= 0)
            {
                return BadRequest();
            }

            var partida = await _context.Partidas.FirstOrDefaultAsync(c => c.idpartida == model.idpartida);

            if (partida == null)
            {
                return NotFound();
            }

            partida.nompartida = model.nompartida;
            partida.despartida = model.despartida;

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

        // POST: api/Partidas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Partida partida = new Partida
            {
                nompartida = model.nompartida,
                despartida = model.despartida
            };

            _context.Partidas.Add(partida);
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

            var partida = await _context.Partidas.FindAsync(id);
            if (partida == null)
            {
                return NotFound();
            }

            _context.Partidas.Remove(partida);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(partida);
        }

        private bool PartidaExists(int id)
        {
            return _context.Partidas.Any(e => e.idpartida == id);
        }
    }
}
