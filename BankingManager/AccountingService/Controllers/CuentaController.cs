using AccountingService.Core.Models;
using AccountingService.Core.DTOs;
using AccountingService.Core.Services;
using Microsoft.AspNetCore.Mvc;
using AccountingService.Core.Exceptions;

namespace AccountingService.Api.Controllers
{
    [ApiController]
    [Route("cuentas")]
    public class CuentaController : ControllerBase
    {
        private readonly ICuentaService _cuentaService;
        public CuentaController(ICuentaService cuentaService)
        {
            _cuentaService = cuentaService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _cuentaService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(String id)
        {
            return Ok(await _cuentaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] PostCuentaDto cuenta)
        {
            if (cuenta == null)
            {
                return BadRequest("El objeto cuenta no puede ser nulo.");
            }

            await _cuentaService.Save(cuenta);
            return CreatedAtAction(nameof(GetById), new { id = cuenta.NumeroCuenta }, cuenta);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cuenta cuenta)
        {
            if (cuenta == null)
            {
                return BadRequest("El objeto cuenta no puede ser nulo.");
            }

            await _cuentaService.Update(cuenta);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await _cuentaService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound($"cuenta con ID {id} no encontrado.");
            }
        }
    }
}
