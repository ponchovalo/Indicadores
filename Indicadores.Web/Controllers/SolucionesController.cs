using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.Solucion;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolucionesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public SolucionesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Descripciones/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SolucionViewModel>> Listar()
        {
            var solucion = await _context.Soluciones.
                Include(t => t.tipofalla).
                Include(c => c.catfalla).
                Include(c => c.causafalla).
                Include(c=> c.tiposol).
                Include(d => d.descripcion).ToListAsync();

            return solucion.Select(d => new SolucionViewModel
            {
                idsolucion = d.idsolucion,
                solucion = d.nomsolucion,
                iddescripcion = d.descripcioniddescripcion,
                descripcion = d.descripcion.descripcion,
                idtipofalla = d.tipofallaidtipofalla,
                tipofalla = d.tipofalla.nomtipofalla,
                idcatfalla = d.catfallaidcatfalla,
                catfalla = d.catfalla.nomcatfalla,
                idcausafalla = d.causafallaidcausafalla,
                causafalla = d.causafalla.nomcausafalla,
                idtiposol = d.tiposolidtiposol,
                tiposol = d.tiposol.nomtiposol
                
            });
        }

        // GET: api/Soluciones/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var solucion = await _context.Soluciones.ToListAsync();

            return solucion.Select(d => new SelectViewModel
            {
                idsolucion = d.idsolucion,
                solucion = d.nomsolucion
            });
        }

        // GET: api/Soluciones/SelectD/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectD([FromRoute] int id)
        {
            var solucion = await _context.Soluciones.Where(u => u.descripcioniddescripcion == id).ToListAsync();

            return solucion.Select(d => new SelectViewModel
            {
                idsolucion = d.idsolucion,
                solucion = d.nomsolucion,
                idtipofalla = d.tipofallaidtipofalla,
                idcatfalla = d.catfallaidcatfalla,
                idcausafalla = d.causafallaidcausafalla,
                idtiposol = d.tiposolidtiposol
            });
        }


        // PUT: api/Soluciones/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idsolucion <= 0)
            {
                return BadRequest();
            }

            var solucion = await _context.Soluciones.FirstOrDefaultAsync(d => d.idsolucion == model.idsolucion);

            if (solucion == null)
            {
                return NotFound();
            }

            solucion.idsolucion = model.idsolucion;
            solucion.descripcioniddescripcion = model.iddescripcion;
            solucion.tipofallaidtipofalla = model.idtipofalla;
            solucion.catfallaidcatfalla = model.idcatfalla;
            solucion.causafallaidcausafalla = model.idcausafalla;
            solucion.tiposolidtiposol = model.idtiposol;
            solucion.nomsolucion = model.solucion;


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

        // POST: api/Soluciones/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Solucion solucion = new Solucion
            {
                descripcioniddescripcion = model.iddescripcion,
                tipofallaidtipofalla = model.idtipofalla,
                catfallaidcatfalla = model.idcatfalla,
                causafallaidcausafalla = model.idcausafalla,
                tiposolidtiposol = model.idtiposol,
                nomsolucion = model.solucion

            };

            _context.Soluciones.Add(solucion);
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

        // GET: api/Soluciones/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var solucion = await _context.Soluciones.FindAsync(id);

            if (solucion == null)
            {
                return NotFound();
            }

            return Ok(new MostrarViewModel
            {
                idsolucion = solucion.idsolucion,
                idtipofalla = solucion.tipofallaidtipofalla,
                idcatfalla = solucion.catfallaidcatfalla,
                idcausafalla = solucion.causafallaidcausafalla,
                idtiposol = solucion.tiposolidtiposol

            });
        }



        private bool SolucionExists(int id)
        {
            return _context.Soluciones.Any(e => e.idsolucion == id);
        }
    }
}
