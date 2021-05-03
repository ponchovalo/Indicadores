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



        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
