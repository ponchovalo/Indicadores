using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.CatFalla;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatFallasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public CatFallasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/CatFallas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CatFallaViewModel>> Listar()
        {
            var catfalla = await _context.CatFallas.ToListAsync();

            return catfalla.Select(c => new CatFallaViewModel
            {
                idcatfalla = c.idcatfalla,
                nomcatfalla = c.nomcatfalla,
                descatfalla = c.descatfalla
            });
        }

        // GET: api/CatFallas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var catfalla = await _context.CatFallas.ToListAsync();

            return catfalla.Select(c => new SelectViewModel
            {
                idcatfalla = c.idcatfalla,
                nomcatfalla = c.nomcatfalla

            });
        }

        // GET: api/CatFallas/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var catfalla = await _context.CatFallas.FindAsync(id);

            if (catfalla == null)
            {
                return NotFound();
            }

            return Ok(new CatFallaViewModel
            {
                idcatfalla = catfalla.idcatfalla,
                nomcatfalla = catfalla.nomcatfalla,
                descatfalla = catfalla.descatfalla
            });
        }

        // PUT: api/CatFallas/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcatfalla <= 0)
            {
                return BadRequest();
            }

            var catfalla = await _context.CatFallas.FirstOrDefaultAsync(c => c.idcatfalla == model.idcatfalla);

            if (catfalla == null)
            {
                return NotFound();
            }

            catfalla.nomcatfalla = model.nomcatfalla;
            catfalla.descatfalla = model.descatfalla;

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

        // POST: api/CatFallas/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CatFalla catfalla = new CatFalla
            {
                nomcatfalla = model.nomcatfalla,
                descatfalla = model.descatfalla
            };

            _context.CatFallas.Add(catfalla);
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

            var catfalla = await _context.CatFallas.FindAsync(id);
            if (catfalla == null)
            {
                return NotFound();
            }

            _context.CatFallas.Remove(catfalla);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(catfalla);
        }




        private bool CatFallaExists(int id)
        {
            return _context.CatFallas.Any(e => e.idcatfalla == id);
        }
    }
}
