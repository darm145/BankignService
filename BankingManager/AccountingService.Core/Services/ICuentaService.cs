using AccountingService.Core.DTOs;
using AccountingService.Core.Models;

namespace AccountingService.Core.Services
{
    public interface ICuentaService
    {
        Task<IEnumerable<Cuenta>> GetAll();
        Task<Cuenta> GetById(string id);
        Task Save(PostCuentaDto cuenta);
        Task Update(Cuenta cuenta);
        Task Delete(string id);
    }
}
