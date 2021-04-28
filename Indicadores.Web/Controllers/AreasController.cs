using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Usuarios;
using Indicadores.Web.Models.Usuarios.Area;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public AreasController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Areas/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AreaViewModel>> Listar()
        {
            var area = await _context.Areas.ToListAsync();

            return area.Select(a => new AreaViewModel
            {
                idarea = a.idarea,
                nomarea = a.nomarea,
                desarea = a.desarea
            });
        }

        // GET: api/Areas/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var area = await _context.Areas.ToListAsync();

            return area.Select(a => new SelectViewModel
            {
                idarea = a.idarea,
                nomarea = a.nomarea
            });
        }



        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.idarea == id);
        }
    }
}
