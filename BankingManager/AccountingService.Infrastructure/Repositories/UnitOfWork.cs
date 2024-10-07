using AccountingService.Core.Repositories;
using AccountingService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace AccountingService.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AccountingDbContext _context;
        private IDbContextTransaction _transaction;
        public ICuentaRepository Cuentas { get; }
        public IMovimientoRepository Movimientos { get; }

        public UnitOfWork(AccountingDbContext context, ICuentaRepository cuentas, IMovimientoRepository movimientos)
        {
            _context = context;
            Cuentas = cuentas;
            Movimientos = movimientos;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
