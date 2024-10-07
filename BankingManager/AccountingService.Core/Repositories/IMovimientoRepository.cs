using AccountingService.Core.Models;

namespace AccountingService.Core.Repositories
{
    public interface IMovimientoRepository
    {
        Task<IEnumerable<Movimiento>> GetAll();
        Task<Movimiento> GetById(int id);
        Task Save(Movimiento movimiento);
        Task Update(Movimiento Movimiento);
        Task Delete(int id);
        Task SaveChangesAsync();
    }
}
