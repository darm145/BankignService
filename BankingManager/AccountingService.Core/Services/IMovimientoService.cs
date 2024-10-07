using AccountingService.Core.DTOs;
using AccountingService.Core.Models;

namespace AccountingService.Core.Services
{
    public interface IMovimientoService
    {
        Task<IEnumerable<Movimiento>> GetAll();
        Task<Movimiento> GetById(int id);
        Task Save(MovimientoDto movimiento);
        Task Update(Movimiento Movimiento);
        Task Delete(int id);
    }
}
