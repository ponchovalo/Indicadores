using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Almacen;
using Indicadores.Web.Models.Almacen.Categoria;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public CategoriasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Categorias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<CategoriaViewModel>> Listar()
        {
            var categoria = await _context.Categorias.ToListAsync();

            return categoria.Select(c => new CategoriaViewModel
            {
                idcategoria = c.idcategoria,
                nomcategoria = c.nomcategoria
            });
        }

        // GET: api/Categorias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var categoria = await _context.Categorias.ToListAsync();

            return categoria.Select(c => new SelectViewModel
            {
                idcategoria = c.idcategoria,
                nomcategoria = c.nomcategoria

            });
        }


        // GET: api/Categorias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(new CategoriaViewModel
            {
                idcategoria = categoria.idcategoria,
                nomcategoria = categoria.nomcategoria
            });
        }

        // PUT: api/Categorias/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcategoria <= 0)
            {
                return BadRequest();
            }

            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.idcategoria == model.idcategoria);

            if (categoria == null)
            {
                return NotFound();
            }

            categoria.nomcategoria = model.nomcategoria;

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

        // POST: api/Categorias/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Categoria categoria = new Categoria
            {
                nomcategoria = model.nomcategoria
            };

            _context.Categorias.Add(categoria);
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

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(categoria);
        }


        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.idcategoria == id);
        }
    }
}
