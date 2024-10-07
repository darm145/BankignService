using Microsoft.AspNetCore.Mvc;
using PersonService.Core.Exceptions;
using PersonService.Core.Models;
using PersonService.Core.Services;

namespace PersonService.Api.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _clienteService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _clienteService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("El objeto cliente no puede ser nulo.");
            }

            await _clienteService.Save(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("El objeto cliente no puede ser nulo.");
            }

            await _clienteService.Update(cliente);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _clienteService.Delete(id);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return NotFound($"Cliente con ID {id} no encontrado.");
            }
        }
    }
}
