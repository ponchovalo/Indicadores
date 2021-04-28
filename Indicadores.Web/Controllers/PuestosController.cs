using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Usuarios;
using Indicadores.Web.Models.Usuarios.Puesto;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PuestosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public PuestosController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Puestos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PuestoViewModel>> Listar()
        {
            var puesto = await _context.Puestos.Include(p => p.area).ToListAsync();

            return puesto.Select(p => new PuestoViewModel
            {
                idpuesto = p.idpuesto,
                idarea = p.areaidarea,
                area = p.area.nomarea,
                nompuesto = p.nompuesto,
                despuesto = p.despuesto
            });
        }

        // GET: api/Puestos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var puesto = await _context.Puestos.ToListAsync();

            return puesto.Select(p => new SelectViewModel
            {
                idpuesto = p.idpuesto,
                nompuesto = p.nompuesto
            });
        }



        private bool PuestoExists(int id)
        {
            return _context.Puestos.Any(e => e.idpuesto == id);
        }
    }
}
