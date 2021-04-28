using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Usuarios;
using Indicadores.Web.Models.Usuarios.Rol;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public RolesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();

            return rol.Select(r => new RolViewModel
            {
                idrol = r.idrol,
                nomrol = r.nomrol,
                desrol = r.desrol,
                condicion = r.condicion
            });
        }

        // GET: api/Roles/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var rol = await _context.Roles.Where(r => r.condicion == true).ToListAsync();

            return rol.Select(r => new SelectViewModel
            {
                idrol = r.idrol,
                nomrol = r.nomrol
            });
        }







        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.idrol == id);
        }
    }
}
