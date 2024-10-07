using AccountingService.Core.Models;

namespace AccountingService.Core.Repositories
{
    public interface ICuentaRepository
    {
        Task<IEnumerable<Cuenta>> GetAll();
        Task<IEnumerable<Cuenta>> GetClientAccounts(int clientid);
        Task<Cuenta> GetById(string id);
        Task Save(Cuenta cuenta);
        Task Update(Cuenta cuenta);
        Task Delete(string id);
        Task SaveChangesAsync();
    }
}
