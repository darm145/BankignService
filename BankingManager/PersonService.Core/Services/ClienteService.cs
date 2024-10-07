using PersonService.Core.Models;
using PersonService.Core.Repositories;

namespace PersonService.Core.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task Delete(int id)
        {
            await _clienteRepository.Delete(id);
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _clienteRepository.GetAll();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _clienteRepository.GetById(id);
        }

        public async Task Save(Cliente cliente)
        {
            await _clienteRepository.Save(cliente);
        }

        public async Task Update(Cliente cliente)
        {
            await _clienteRepository.Update(cliente);
        }
    }
}
