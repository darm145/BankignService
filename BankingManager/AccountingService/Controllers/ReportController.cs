using AccountingService.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingService.Api.Controllers
{
    [Route("reportes")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReporteService _reporteService;
        public ReportController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEstadoCuenta([FromQuery] DateTime fechaInicio, [FromQuery] DateTime fechaFin, [FromQuery] int clienteId)
        {
            try
            {
                return Ok(await _reporteService.GetEstadoCuenta(clienteId, fechaInicio, fechaFin));
            }
            catch { 
                return BadRequest("error al generar el reporte");
            }
        }
    }
}
