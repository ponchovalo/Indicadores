using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Indicadores.Datos;
using Indicadores.Entidades.Impresion;
using Indicadores.Web.Models.Impresion.ReporteMes;

namespace Indicadores.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteMesController : ControllerBase
    {
        private readonly DbContextIndicadores _context;

        public ReporteMesController(DbContextIndicadores context)
        {
            _context = context;
        }

        // GET: api/ReporteMes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReporteMes>>> GetReportesMes()
        {
            return await _context.ReportesMes.Include(i => i.impresora).ToListAsync();
        }

        
        // GET: api/ReporteMes/2021/2
        [HttpGet("{year}/{month}")]
        public async Task<IEnumerable<ReporteMesViewModel>> BuscarMonthYear(int month, int year)
        {
            var reporte = await _context.ReportesMes.Include(i => i.impresora).Where(y => y.year == year).Where(m => m.month == month).ToListAsync();

            return reporte.Select(c => new ReporteMesViewModel
            {
                idreporte = c.idreporte,
                contador109 = c.contador109,
                contador124 = c.contador124,
                contador102 = c.contador102,
                vpbyn = c.vpbyn,
                vpcolor = c.vpcolor,
                year = c.year,
                month = c.month,
                impresora = c.impresora
            });
        }









        // GET: api/ReporteMes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReporteMes>> GetReporteMes(int id)
        {
            var reporteMes = await _context.ReportesMes.FindAsync(id);

            if (reporteMes == null)
            {
                return NotFound();
            }

            return reporteMes;
        }






        // PUT: api/ReporteMes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReporteMes(int id, ReporteMes reporteMes)
        {
            if (id != reporteMes.idreporte)
            {
                return BadRequest();
            }

            _context.Entry(reporteMes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteMesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReporteMes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ReporteMes>> PostReporteMes(ReporteMes reporteMes)
        {
            _context.ReportesMes.Add(reporteMes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReporteMes", new { id = reporteMes.idreporte }, reporteMes);
        }

        // DELETE: api/ReporteMes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ReporteMes>> DeleteReporteMes(int id)
        {
            var reporteMes = await _context.ReportesMes.FindAsync(id);
            if (reporteMes == null)
            {
                return NotFound();
            }

            _context.ReportesMes.Remove(reporteMes);
            await _context.SaveChangesAsync();

            return reporteMes;
        }

        private bool ReporteMesExists(int id)
        {
            return _context.ReportesMes.Any(e => e.idreporte == id);
        }
    }
}
