using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Almacen;
using Indicadores.Web.Models.Almacen.Herramienta;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HerramientasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public HerramientasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Herramientas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<HerramientaViewModel>> Listar()
        {
            var herramienta = await _context.Herramientas.ToListAsync();

            return herramienta.Select(c => new HerramientaViewModel
            {
                idherramienta = c.idherramienta,
                nomherramienta = c.nomherramienta,
                desherramienta = c.desherramienta
            });
        }

        // GET: api/Herramienta/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var herramienta = await _context.Herramientas.ToListAsync();

            return herramienta.Select(c => new SelectViewModel
            {
                idherramienta = c.idherramienta,
                nomherramienta = c.nomherramienta

            });
        }


        // GET: api/Herramientas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var herramienta = await _context.Herramientas.FindAsync(id);

            if (herramienta == null)
            {
                return NotFound();
            }

            return Ok(new HerramientaViewModel
            {
                idherramienta = herramienta.idherramienta,
                nomherramienta = herramienta.nomherramienta,
                desherramienta = herramienta.desherramienta
            });
        }

        // PUT: api/Herramientas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idherramienta <= 0)
            {
                return BadRequest();
            }

            var herramienta = await _context.Herramientas.FirstOrDefaultAsync(c => c.idherramienta == model.idherramienta);

            if (herramienta == null)
            {
                return NotFound();
            }

            herramienta.nomherramienta = model.nomherramienta;
            herramienta.desherramienta = model.desherramienta;

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

        // POST: api/Herramientas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Herramienta herramienta = new Herramienta
            {
                nomherramienta = model.nomherramienta,
                desherramienta = model.desherramienta
            };

            _context.Herramientas.Add(herramienta);
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

        // DELETE: api/Herramientas/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var herramienta = await _context.Herramientas.FindAsync(id);
            if (herramienta == null)
            {
                return NotFound();
            }

            _context.Herramientas.Remove(herramienta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(herramienta);
        }



        private bool HerramientaExists(int id)
        {
            return _context.Herramientas.Any(e => e.idherramienta == id);
        }
    }
}
