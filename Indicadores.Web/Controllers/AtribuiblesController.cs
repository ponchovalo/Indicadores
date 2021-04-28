using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Descripcion;
using Indicadores.Web.Models.Descripcion.Atribuible;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtribuiblesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public AtribuiblesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Atribuibles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AtribuibleViewModel>> Listar()
        {
            var atribuible = await _context.Atribuibles.ToListAsync();

            return atribuible.Select(a => new AtribuibleViewModel
            {
                idatribuible = a.idatribuible,
                atribcorto = a.atribcorto,
                nomatrib = a.nomatrib,
                desatrib = a.desatrib

            });
        }

        // GET: api/Atribuibles/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var atribuible = await _context.Atribuibles.Where(a => a.condicion == true).ToListAsync();

            return atribuible.Select(a => new SelectViewModel
            {
                idatribuible = a.idatribuible,
                atribcorto = a.atribcorto,
                nomatrib = a.nomatrib

            });
        }




        private bool AtribuibleExists(int id)
        {
            return _context.Atribuibles.Any(e => e.idatribuible == id);
        }
    }
}
