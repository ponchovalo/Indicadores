using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.ActividadAdm;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadAdmsController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public ActividadAdmsController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/ActividadAdms/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ActividadAdmViewModel>> Listar()
        {
            var actividadadm = await _context.ActividadAdms.ToListAsync();

            return actividadadm.Select(a => new ActividadAdmViewModel
            {
                idactividadadm = a.idactividadadm,
                nomactividadadm = a.nomactividadadm,
                desactividadadm = a.desactividadadm

            });
        }

        // GET: api/ActividadAdms/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var actividadadm = await _context.ActividadAdms.ToListAsync();

            return actividadadm.Select(a => new SelectViewModel
            {
                idactividadadm = a.idactividadadm,
                nomactividadadm = a.nomactividadadm

            });
        }

        // GET: api/ActividadAdms/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var actividadadm = await _context.ActividadAdms.FindAsync(id);

            if (actividadadm == null)
            {
                return NotFound();
            }

            return Ok(new ActividadAdmViewModel
            {
                idactividadadm = actividadadm.idactividadadm,
                nomactividadadm = actividadadm.nomactividadadm,
                desactividadadm = actividadadm.desactividadadm
            });
        }

        // PUT: api/ActividadAdms/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idactividadadm <= 0)
            {
                return BadRequest();
            }

            var actividadadm = await _context.ActividadAdms.FirstOrDefaultAsync(c => c.idactividadadm == model.idactividadadm);

            if (actividadadm == null)
            {
                return NotFound();
            }

            actividadadm.nomactividadadm = model.nomactividadadm;
            actividadadm.desactividadadm = model.desactividadadm;

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

        // POST: api/ActividadAdms/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ActividadAdm actividadadm = new ActividadAdm
            {
                nomactividadadm = model.nomactividadadm,
                desactividadadm = model.desactividadadm
            };

            _context.ActividadAdms.Add(actividadadm);
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

        // DELETE: api/ActividadAdms/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var actividadadm = await _context.ActividadAdms.FindAsync(id);
            if (actividadadm == null)
            {
                return NotFound();
            }

            _context.ActividadAdms.Remove(actividadadm);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(actividadadm);
        }



        private bool ActividadAdmExists(int id)
        {
            return _context.ActividadAdms.Any(e => e.idactividadadm == id);
        }
    }
}
