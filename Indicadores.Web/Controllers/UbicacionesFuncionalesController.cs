using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Ubicacion;
using Indicadores.Web.Models.Ubicacion.UbicacionFuncional;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionesFuncionalesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public UbicacionesFuncionalesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/UbicacionesFuncionales/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UbicacionFuncionalViewModel>> Listar()
        {
            var ubicacion = await _context.UbicacionesFuncionales.ToListAsync();

            return ubicacion.Select(d => new UbicacionFuncionalViewModel
            {
                idubicacion = d.idubicacionfuncional,
                idarea = d.areafuncionalidareafuncional,
                idtec = d.tecidtec,
                idubictec = d.idubictec,
                dentec = d.dentec,
                nomubicacion = d.nomubicacion
            });
        }

        // GET: api/UbicacionesFuncionales/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var ubicacion = await _context.UbicacionesFuncionales.ToListAsync();

            return ubicacion.Select(d => new SelectViewModel
            {
                idubicacion = d.idubicacionfuncional,
                idubictec = d.idubictec,
                nomubicacion = d.nomubicacion
            });
        }

        // GET: api/Dispositivos/SelectP/1
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> SelectP([FromRoute] string id)
        {
            var ubicacion = await _context.UbicacionesFuncionales.Where(u => u.tecidtec == id).ToListAsync();

            return ubicacion.Select(d => new SelectViewModel
            {
                idubicacion = d.idubicacionfuncional,
                idubictec = d.idubictec,
                nomubicacion = d.nomubicacion
            });
        }

        private bool UbicacionFuncionalExists(int id)
        {
            return _context.UbicacionesFuncionales.Any(e => e.idubicacionfuncional == id);
        }
    }
}
