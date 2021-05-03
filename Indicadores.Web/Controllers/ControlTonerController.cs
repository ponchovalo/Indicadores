using Indicadores.Datos;
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
                impresora = c.impresora.nombreimpresora,
                idimpresora = c.impresoraidimpresora,
                usuario = c.usuario.nomusuario,
                idusuario = c.usuarioidusuario
            });
        }

        // GET api/<ControlTonerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
