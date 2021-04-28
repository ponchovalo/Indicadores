using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.Desc;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescripcionesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public DescripcionesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Descripciones/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<DescripcionViewModel>> Listar()
        {
            var descripcion = await _context.Descripciones.
                Include(p => p.partida).
                Include(d => d.dispositivo).
                Include(a => a.actividad).
                Include(t => t.tipoactividad).
                Include(m => m.actividadadm).ToListAsync();

            return descripcion.Select(d => new DescripcionViewModel
            {
                iddescripcion = d.iddescripcion,
                idpartida = d.partidaidpartida,
                partida = d.partida.nompartida,
                iddispositivo = d.dispositivoiddispositivo,
                dispositivo = d.dispositivo.nomdispositivo,
                idactividad = d.actividadidactividad,
                actividad = d.actividad.nomactividad,
                idtipoactividad = d.tipoactividadidtipoactividad,
                tipoactividad = d.tipoactividad.nomtipoactividad,
                idactividadadm = d.actividadadmidactividadadm,
                actividadadm = d.actividadadm.nomactividadadm,
                descripcion = d.descripcion

            });
        }

        // GET: api/Descripciones/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var descripcion = await _context.Descripciones.ToListAsync();

            return descripcion.Select(d => new SelectViewModel
            {
                iddescripcion = d.iddescripcion,
                descripcion = d.descripcion
            });
        }

        // GET: api/Descripciones/SelectD/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectD([FromRoute] int id)
        {
            var descripcion = await _context.Descripciones.Where(u => u.dispositivoiddispositivo == id).ToListAsync();

            return descripcion.Select(d => new SelectViewModel
            {
                iddescripcion = d.iddescripcion,
                descripcion = d.descripcion
            });
        }

        // PUT: api/Descripciones/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.iddescripcion <= 0)
            {
                return BadRequest();
            }

            var descripcion = await _context.Descripciones.FirstOrDefaultAsync(d => d.iddescripcion == model.iddescripcion);

            if (descripcion == null)
            {
                return NotFound();
            }

            descripcion.iddescripcion = model.iddescripcion;
            descripcion.partidaidpartida = model.idpartida;
            descripcion.dispositivoiddispositivo = model.iddispositivo;
            descripcion.actividadidactividad = model.idactividad;
            descripcion.tipoactividadidtipoactividad = model.idtipoactividad;
            descripcion.actividadadmidactividadadm = model.idactividadadm;
            descripcion.descripcion = model.descripcion;

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

        // POST: api/Descripciones/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Desc descripcion = new Desc
            {
                partidaidpartida = model.idpartida,
                dispositivoiddispositivo = model.iddispositivo,
                actividadidactividad = model.idactividad,
                tipoactividadidtipoactividad = model.idtipoactividad,
                actividadadmidactividadadm = model.idactividadadm,
                descripcion = model.descripcion
            };

            _context.Descripciones.Add(descripcion);
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



        private bool DescExists(int id)
        {
            return _context.Descripciones.Any(e => e.iddescripcion == id);
        }
    }
}
