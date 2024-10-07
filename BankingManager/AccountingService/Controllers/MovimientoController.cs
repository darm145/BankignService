using AccountingService.Core.DTOs;
using AccountingService.Core.Exceptions;
using AccountingService.Core.Models;
using AccountingService.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccountingService.Api.Controllers
{
    [ApiController]
    [Route("movimientos")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;
        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _movimientoService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _movimientoService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] MovimientoDto movimiento)
        {
            if (movimiento == null)
            {
                return BadRequest("El objeto movimiento no puede ser nulo.");
            }

            await _movimientoService.Save(movimiento);
            return CreatedAtAction(nameof(GetById), new { id = movimiento.MovimientoId }, movimiento);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Movimiento movimiento)
        {
            if (movimiento == null)
            {
                return BadRequest("El objeto movimiento no puede ser nulo.");
            }

            await _movimientoService.Update(movimiento);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _movimientoService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound($"movimiento con ID {id} no encontrado.");
            }
        }
    }
}
