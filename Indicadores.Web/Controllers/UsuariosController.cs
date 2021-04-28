using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Indicadores.Datos;
using Indicadores.Entidades.Usuarios;
using Indicadores.Web.Models.Usuarios.Usuario;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextIndicadores _context;
        private readonly IConfiguration _config;

        public UsuariosController(DbContextIndicadores context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Usuarios/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuario = await _context.Usuarios.
                Include(r => r.rol).
                Include(a => a.area).
                Include(p => p.puesto).ToListAsync();

            return usuario.Select(u => new UsuarioViewModel
            {
                idusuario = u.idusuario,
                idrol = u.rolidrol,
                rol = u.rol.nomrol,
                idarea = u.areaidarea,
                area = u.area.nomarea,
                idpuesto = u.puestoidpuesto,
                puesto = u.puesto.nompuesto,
                nomusuario = u.nomusuario,
                emailusuario = u.emailusuario,
                password_hash = u.password_hash,
                condicion = u.condicion,
                user = u.user

            });
        }

        // POST: api/Usuarios/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var email = model.emailusuario.ToLower();
            if (await _context.Usuarios.AnyAsync(u => u.emailusuario == email))
            {
                return BadRequest("El email ya existe");
            }

            CrearPasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);

            Usuario usuario = new Usuario
            {
                rolidrol = model.idrol,
                areaidarea = model.idarea,
                puestoidpuesto = model.idpuesto,
                nomusuario = model.nomusuario,
                emailusuario = model.emailusuario.ToLower(),
                user = model.user,
                password_hash = passwordHash,
                password_salt = passwordSalt,
                condicion = true
            };

            _context.Usuarios.Add(usuario);
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

        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using ( var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        // PUT: api/Usuarios/Actualizar
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idusuario <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idusuario == model.idusuario);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.idusuario = model.idusuario;
            usuario.rolidrol = model.idrol;
            usuario.areaidarea = model.idarea;
            usuario.puestoidpuesto = model.idpuesto;
            usuario.nomusuario = model.nomusuario;
            usuario.emailusuario = model.emailusuario.ToLower();
            usuario.user = model.user;
            
            if( model.act_password == true)
            {
                CrearPasswordHash(model.password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.password_hash = passwordHash;
                usuario.password_salt = passwordSalt;
            }

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

        // PUT: api/Usuarios/Desactivar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idusuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.condicion = false;

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

        // PUT: api/Usuarios/Activar/1
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idusuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.condicion = true;

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

        // POST: api/Usuarios/Login
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = model.user;

            var usuario = await _context.Usuarios.Where(u=>u.condicion==true).
                Include(u => u.rol).
                Include(a =>a.area).
                Include(p => p.puesto).
                FirstOrDefaultAsync(u=>u.user==user);

            if (usuario == null)
            {
                return NotFound();
            }

            if (!VerificarPasswordHash(model.password,usuario.password_hash,usuario.password_salt))
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idusuario.ToString()),
                new Claim(ClaimTypes.Name, user),
                new Claim(ClaimTypes.Role, usuario.rol.nomrol ),
                new Claim("idusuario", usuario.idusuario.ToString() ),
                new Claim("rol", usuario.rol.nomrol ),
                new Claim("nombre", usuario.nomusuario ),
                new Claim("area", usuario.area.nomarea ),
                new Claim("puesto", usuario.puesto.nompuesto)
            };

            return Ok(
                    new {token = GenerarToken(claims)}
                );

        }

        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }

        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              _config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds,
              claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idusuario == id);
        }
    }
}
