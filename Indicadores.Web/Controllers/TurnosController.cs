using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Horario;
using Indicadores.Web.Models.Horario.Turno;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public TurnosController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Turnos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<TurnoViewModel>> Listar()
        {
            var turno = await _context.Turnos.ToListAsync();

            return turno.Select(c => new TurnoViewModel
            {
                idturno = c.idturno,
                nomturno = c.nomturno,
                horario = c.horario
            });
        }

        // GET: api/Turnos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var turno = await _context.Turnos.ToListAsync();

            return turno.Select(c => new SelectViewModel
            {
                idturno = c.idturno,
                nomturno = c.nomturno,
                horario = c.horario

            });
        }

        // GET: api/Turnos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var turno = await _context.Turnos.FindAsync(id);

            if (turno == null)
            {
                return NotFound();
            }

            return Ok(new TurnoViewModel
            {
                idturno = turno.idturno,
                nomturno = turno.nomturno,
                horario = turno.horario
            });
        }

        // PUT: api/Turnos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idturno <= 0)
            {
                return BadRequest();
            }

            var turno = await _context.Turnos.FirstOrDefaultAsync(c => c.idturno == model.idturno);

            if (turno == null)
            {
                return NotFound();
            }

            turno.nomturno = model.nomturno;
            turno.horario = model.horario;

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

        // POST: api/Turnos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Turno turno = new Turno
            {
                nomturno = model.nomturno,
                horario = model.horario
            };

            _context.Turnos.Add(turno);
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

        // DELETE: api/Turnos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }

            _context.Turnos.Remove(turno);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(turno);
        }




        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.idturno == id);
        }
    }
}
