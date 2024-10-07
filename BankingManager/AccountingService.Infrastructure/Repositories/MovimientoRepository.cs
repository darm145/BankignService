using AccountingService.Core.Exceptions;
using AccountingService.Core.Models;
using AccountingService.Core.Repositories;
using AccountingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AccountingService.Infrastructure.Repositories
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly AccountingDbContext _context;

        public MovimientoRepository(AccountingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            return await _context.Movimientos.ToListAsync();
        }

        public async Task<Movimiento> GetById(int id)
        {
            return await _context.Movimientos.FindAsync(id);
        }

        public async Task Save(Movimiento movimiento)
        {
            await _context.Movimientos.AddAsync(movimiento);
            
        }

        public async Task Update(Movimiento movimiento)
        {
            _context.Movimientos.Update(movimiento);
            
        }

        public async Task Delete(int id)
        {
            var movimiento = await _context.Movimientos.FindAsync(id);
            if (movimiento != null)
            {
                _context.Movimientos.Remove(movimiento);
                
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
    }
}
