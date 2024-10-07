using Microsoft.EntityFrameworkCore;
using PersonService.Core.Exceptions;
using PersonService.Core.Models;
using PersonService.Core.Repositories;
using PersonService.Infrastructure.Data;

namespace PersonService.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly PersonDbContext _context;

        public ClienteRepository(PersonDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetById(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task Save(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException($"cuenta con ID {id} no encontrado.");
            }
        }
    }
}
