namespace AccountingService.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICuentaRepository Cuentas { get; }
        IMovimientoRepository Movimientos { get; }
        Task<int> SaveAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
