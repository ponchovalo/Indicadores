using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Almacen;
using Indicadores.Web.Models.Almacen.Insumo;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsumosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public InsumosController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Insumos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<InsumoViewModel>> Listar()
        {
            var insumo = await _context.Insumos.Include(d => d.categoria).ToListAsync();

            return insumo.Select(d => new InsumoViewModel
            {
                idinsumo = d.idinsumo,
                idcategoria = d.categoriaidcategoria,
                categoria = d.categoria.nomcategoria,
                nominsumo = d.nominsumo,
                desinsumo = d.desinsumo
            });
        }
        // GET: api/Dispositivos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var insumo = await _context.Insumos.ToListAsync();

            return insumo.Select(d => new SelectViewModel
            {
                idinsumo = d.idinsumo,
                nominsumo = d.nominsumo,
            });
        }
        // GET: api/Insumos/SelectP/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectP([FromRoute] int id)
        {
            var insumo = await _context.Insumos.Where(u => u.categoriaidcategoria == id).ToListAsync();

            return insumo.Select(d => new SelectViewModel
            {
                idinsumo = d.idinsumo,
                nominsumo = d.nominsumo,
            });
        }
        // GET: api/Insumos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var insumo = await _context.Insumos.Include(d => d.categoria).SingleOrDefaultAsync(d => d.idinsumo == id);

            if (insumo == null)
            {
                return NotFound();
            }

            return Ok(new InsumoViewModel
            {
                idinsumo = insumo.idinsumo,
                idcategoria = insumo.categoria.idcategoria,
                categoria = insumo.categoria.nomcategoria,
                nominsumo = insumo.nominsumo,
                desinsumo = insumo.desinsumo
            });
        }

        // PUT: api/Insumos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idinsumo <= 0)
            {
                return BadRequest();
            }

            var insumo = await _context.Insumos.FirstOrDefaultAsync(d => d.idinsumo == model.idinsumo);

            if (insumo == null)
            {
                return NotFound();
            }

            insumo.idinsumo = model.idinsumo;
            insumo.categoriaidcategoria = model.idcategoria;
            insumo.nominsumo = model.nominsumo;
            insumo.desinsumo = model.desinsumo;

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

        // POST: api/Insumos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Insumo insumo = new Insumo
            {
                categoriaidcategoria = model.idcategoria,
                nominsumo = model.nominsumo,
                desinsumo = model.desinsumo

            };

            _context.Insumos.Add(insumo);
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

        // DELETE: api/Insumos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var insumo = await _context.Insumos.FindAsync(id);
            if (insumo == null)
            {
                return NotFound();
            }

            _context.Insumos.Remove(insumo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(insumo);
        }



        private bool InsumoExists(int id)
        {
            return _context.Insumos.Any(e => e.idinsumo == id);
        }
    }
}
