using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Ubicacion;
using Indicadores.Web.Models.Ubicacion.AreaFuncional;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasFuncionalesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public AreasFuncionalesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/AreasFuncionales/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<AreaFuncionalViewModel>> Listar()
        {
            var areafunc = await _context.AreasFuncionales.ToListAsync();

            return areafunc.Select(c => new AreaFuncionalViewModel
            {
                idarea = c.idareafuncional,
                idtec = c.idtec,
                dentec = c.dentec,
                nomarea = c.nomarea
            });
        }
        // GET: api/AreasFuncionales/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var areafunc = await _context.AreasFuncionales.ToListAsync();

            return areafunc.Select(c => new SelectViewModel
            {
                idarea = c.idareafuncional,
                idtec = c.idtec,
                nomarea = c.nomarea

            });
        }


        private bool AreaFuncionalExists(int id)
        {
            return _context.AreasFuncionales.Any(e => e.idareafuncional == id);
        }
    }
}
