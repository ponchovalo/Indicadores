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




        // POST: api/ReporteMes/Crear
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] ReporteViewModel model)
        {
   
            try
            {
                foreach (var det in model.registros)
                {
                    
                    var imp = _context.ReportesMes
                    .Include(i => i.impresora)
                    .FirstOrDefault(i => i.impresoraidimpresora == det.impresora.idimpresora && i.month == (det.month - 1) && i.year == det.year);

                    if (imp == null)
                    {
                        return NotFound();
                    }
                                    
                    ReporteMes reporte = new ReporteMes
                    {
                        idreporte = det.idreporte,
                        contador109 = det.contador109,
                        contador124 = det.contador124,
                        contador102 = det.contador102,
                        vpbyn = det.contador109 - imp.contador109,
                        vpcolor = det.contador124 - imp.contador124,
                        year = det.year,
                        month = det.month,
                        impresoraidimpresora = det.impresora.idimpresora
                    };
                    _context.ReportesMes.Add(reporte);
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

            return Ok();
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
