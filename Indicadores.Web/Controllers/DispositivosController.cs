using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Administracion.Dispositivo;
using Indicadores.Web.Models.Descripcion.Dispositivo;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispositivosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public DispositivosController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Dispositivos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<DispositivoViewModel>> Listar()
        {
            var dispositivo = await _context.Dispositivos.Include(d => d.partida).ToListAsync();

            return dispositivo.Select(d => new DispositivoViewModel
            {
                iddispositivo = d.iddispositivo,
                idpartida = d.partidaidpartida,
                partida = d.partida.nompartida,
                nomdispositivo = d.nomdispositivo,
                desdispositivo = d.desdispositivo
            });
        }
        // GET: api/Dispositivos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var dispositivo = await _context.Dispositivos.ToListAsync();

            return dispositivo.Select(d => new SelectViewModel
            {
                iddispositivo = d.iddispositivo,
                nomdispositivo = d.nomdispositivo,
            });
        }
        // GET: api/Dispositivos/SelectP/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectP([FromRoute] int id)
        {
            var dispositivo = await _context.Dispositivos.Where(u => u.partidaidpartida == id).ToListAsync();

            return dispositivo.Select(d => new SelectViewModel
            {
                iddispositivo = d.iddispositivo,
                nomdispositivo = d.nomdispositivo,
            });
        }
        // GET: api/Dispositivos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var dispositivo = await _context.Dispositivos.Include(d => d.partida).SingleOrDefaultAsync(d => d.iddispositivo == id);

            if (dispositivo == null)
            {
                return NotFound();
            }

            return Ok(new DispositivoViewModel
            {
                iddispositivo = dispositivo.iddispositivo,
                idpartida = dispositivo.partida.idpartida,
                partida = dispositivo.partida.nompartida,
                nomdispositivo = dispositivo.nomdispositivo,
                desdispositivo = dispositivo.desdispositivo
            });
        }

        // PUT: api/Dispositivos/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.iddispositivo <= 0)
            {
                return BadRequest();
            }

            var dispositivo = await _context.Dispositivos.FirstOrDefaultAsync(d => d.iddispositivo == model.iddispositivo);

            if (dispositivo == null)
            {
                return NotFound();
            }

            dispositivo.iddispositivo = model.iddispositivo;
            dispositivo.partidaidpartida = model.idpartida;
            dispositivo.nomdispositivo = model.nomdispositivo;
            dispositivo.desdispositivo = model.desdispositivo;

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

        // POST: api/Dispositivos/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Dispositivo dispositivo = new Dispositivo
            {
                partidaidpartida = model.idpartida,
                nomdispositivo = model.nomdispositivo,
                desdispositivo = model.desdispositivo
                
            };

            _context.Dispositivos.Add(dispositivo);
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

        // DELETE: api/Dispositivos/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dispositivo = await _context.Dispositivos.FindAsync(id);
            if (dispositivo == null)
            {
                return NotFound();
            }

            _context.Dispositivos.Remove(dispositivo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(dispositivo);
        }
        private bool DispositivoExists(int id)
        {
            return _context.Dispositivos.Any(e => e.iddispositivo == id);
        }
    }
}
