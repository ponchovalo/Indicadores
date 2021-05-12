using Indicadores.Datos;
using Indicadores.Entidades.Impresion;
using Indicadores.Web.Models.Impresion.ControlT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlTonerController : ControllerBase
    {
        private readonly DbContextIndicadores _context;
        public ControlTonerController(DbContextIndicadores context)
        {
            _context = context;
        }
        // GET: api/ControlToner/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ControlTonerViewModel>> Listar()
        {
            var controltoner = await _context.ControlToners
                .Include(c => c.impresora)
                .Include(u => u.usuario)
                .ToListAsync();

            return controltoner.Select(c => new ControlTonerViewModel
            {
                idcontrol = c.idcontrol,
                contador109 = c.contador109,
                contador124 = c.contador124,
                contador102 = c.contador102,
                fecha = c.fecha,
                idimpresora = c.impresoraidimpresora,
                impresora = c.impresora.nombreimpresora,
                idusuario = c.usuarioidusuario,
                usuario = c.usuario.nomusuario
            });
        }

        // POST: api/ControlToner/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearControlTViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ControlToner control = new ControlToner
            {
                contador109 = model.contador109,
                contador124 = model.contador124,
                contador102 = model.contador102,
                toner = model.toner,
                fecha = model.fecha,
                impresoraidimpresora = model.idimpresora,
                usuarioidusuario = Int32.Parse(model.idusuario)
            };

            _context.ControlToners.Add(control);
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

        // PUT: api/ControlToner/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarControlTViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idcontrol <= 0)
            {
                return BadRequest();
            }

            var control = await _context.ControlToners.FirstOrDefaultAsync(d => d.idcontrol == model.idcontrol);

            if (control == null)
            {
                return NotFound();
            }

            control.idcontrol = model.idcontrol;
            control.fecha = model.fecha;
            control.contador102 = model.contador102;
            control.contador109 = model.contador109;
            control.contador124 = model.contador124;
            control.impresoraidimpresora = model.idimpresora;
            control.usuarioidusuario = model.idusuario;

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

        // DELETE: api/ControlToner/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var control = await _context.ControlToners.FindAsync(id);
            if (control == null)
            {
                return NotFound();
            }

            _context.ControlToners.Remove(control);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(control);
        }

        // POST api/<ControlTonerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ControlTonerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ControlTonerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
