using AccountingService.Core.Exceptions;
using AccountingService.Core.Models;
using AccountingService.Core.Repositories;
using AccountingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingService.Infrastructure.Repositories
{
    public class CuentaRepository : ICuentaRepository
    {
        private readonly AccountingDbContext _context;

        public CuentaRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            return await _context.Cuentas.ToListAsync();
        }

        public async Task<Cuenta> GetById(string id)
        {
            return await _context.Cuentas.FindAsync(id);
        }

        public async Task Save(Cuenta cuenta)
        {
            await _context.Cuentas.AddAsync(cuenta);
            
        }

        public async Task Update(Cuenta cuenta)
        {
            _context.Cuentas.Update(cuenta);
            
        }

        public async Task Delete(string id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta != null)
            {
                _context.Cuentas.Remove(cuenta);
                
            }
            else
            {
                throw new NotFoundException($"cuenta con ID {id} no encontrado.");
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetClientAccounts(int clientid)
        {
            return await _context.Cuentas.Include(c => c.Movimientos)
                .Where(c => c.ClienteId == clientid).ToListAsync();
        }
    }
}
