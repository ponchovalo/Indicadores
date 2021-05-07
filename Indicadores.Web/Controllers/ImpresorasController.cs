using Indicadores.Datos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indicadores.Web.Models.Impresion.Impresora;
using Microsoft.EntityFrameworkCore;
using Indicadores.Web.Models.Impresion.ControlT;
using Indicadores.Entidades.Impresion;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpresorasController : ControllerBase
    {

        private readonly DbContextIndicadores _context;

        public ImpresorasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Impresoras/Listar
        [HttpGet("[action]")]
        public async Task <IEnumerable<ImpresoraViewModel>> Listar()
        {
            var impresora = await _context.Impresoras.ToListAsync();

            return impresora.Select(i => new ImpresoraViewModel
            {
                idimpresora = i.idimpresora,
                nombreimpresora= i.nombreimpresora,
                modeloimpresora = i.modeloimpresora,
                serieimpresora = i.serieimpresora,
                ipimpresora = i.ipimpresora,
                macimpresora = i.macimpresora,
                edificioimpresora = i.edificioimpresora,
                ubicacionimpresora = i.ubicacionimpresora
            });
        }

        // GET: api/Impresoras/ListarCambios
        [HttpGet("[action]")]
        public async Task<IEnumerable<ImpresorasTonerViewModel>> ListarCambios()
        {
            var impresora = await _context.Impresoras
                .Include(c => c.listacambios)
                .ToListAsync();

            var lista = await _context.ControlToners
                .Include(u => u.usuario)
                .ToListAsync();

            return impresora.Select(i => new ImpresorasTonerViewModel
            {
                idimpresora = i.idimpresora,
                nombreimpresora = i.nombreimpresora,
                modeloimpresora = i.modeloimpresora,
                cambios = i.listacambios.Select(c => new ControlTonerListaImpViewmodel
                {
                    idcontrol = c.idcontrol,
                    fecha = c.fecha,
                    idimpresora = c.impresoraidimpresora,
                    idusuario = c.usuarioidusuario,
                    usuario = c.usuario.nomusuario
                }).ToList()
   
            });
        }

        // GET: api/Impresoras/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Mostrar([FromRoute] int id)
        {
            var impresora = await _context.Impresoras.FindAsync(id);

            if (impresora == null)
            {
                return NotFound();
            }

            return Ok(new ImpresoraViewModel
            {
                idimpresora = impresora.idimpresora,
                nombreimpresora = impresora.nombreimpresora,
                modeloimpresora = impresora.modeloimpresora,
                serieimpresora = impresora.serieimpresora,
                ipimpresora = impresora.ipimpresora,
                macimpresora = impresora.macimpresora,
                edificioimpresora = impresora.edificioimpresora,
                ubicacionimpresora = impresora.ubicacionimpresora
            });
        }
        // PUT: api/Impresoras/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarImpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idimpresora <= 0)
            {
                return BadRequest();
            }

            var impresora = await _context.Impresoras.FirstOrDefaultAsync(c => c.idimpresora == model.idimpresora);

            if (impresora == null)
            {
                return NotFound();
            }
            impresora.nombreimpresora = model.nombreimpresora;
            impresora.modeloimpresora = model.modeloimpresora;
            impresora.serieimpresora = model.serieimpresora;
            impresora.ipimpresora = model.ipimpresora;
            impresora.macimpresora = model.macimpresora;
            impresora.edificioimpresora = model.edificioimpresora;
            impresora.ubicacionimpresora = model.ubicacionimpresora;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Guardar Excepción
                return BadRequest();
            }

            return Ok(impresora);
        }

        // POST: api/Impresoras/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearImpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Impresora impresora = new Impresora
            {
                nombreimpresora = model.nombreimpresora,
                modeloimpresora = model.modeloimpresora,
                serieimpresora = model.serieimpresora,
                ipimpresora = model.ipimpresora,
                macimpresora = model.macimpresora,
                edificioimpresora = model.edificioimpresora,
                ubicacionimpresora = model.ubicacionimpresora
            };

            _context.Impresoras.Add(impresora);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(impresora);
        }

        // DELETE: api/Impresoras/Eliminar/1
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var impresora = await _context.Impresoras.FindAsync(id);
            if (impresora == null)
            {
                return NotFound();
            }

            _context.Impresoras.Remove(impresora);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok(impresora);
        }


    }
}
