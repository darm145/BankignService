using PersonService.Core.Models;

namespace PersonService.Core.Repositories
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> GetById(int id);
        Task Save(Cliente cliente);
        Task Update(Cliente cliente);
        Task Delete(int id);

    }
}
