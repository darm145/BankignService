using AccountingService.Core.DTOs;
using AccountingService.Core.Models;
using AccountingService.Core.Repositories;

namespace AccountingService.Core.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository _cuentaRepository;

        public CuentaService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task Delete(string id)
        {
            await _cuentaRepository.Delete(id);
            await _cuentaRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cuenta>> GetAll()
        {
            return await _cuentaRepository.GetAll();
        }

        public async Task<Cuenta> GetById(string id)
        {
            return await _cuentaRepository.GetById(id);
        }

        public async Task Save(PostCuentaDto cuenta)
        {
            var cuentafinal = new Cuenta
            {
                ClienteId = cuenta.ClienteId,
                SaldoInicial = cuenta.SaldoInicial,
                Estado = cuenta.Estado,
                NumeroCuenta = cuenta.NumeroCuenta,
                TipoCuenta = cuenta.TipoCuenta,
                Movimientos = null
            };
            await _cuentaRepository.Save(cuentafinal);
            await _cuentaRepository.SaveChangesAsync();
        }

        public async Task Update(Cuenta cuenta)
        {
            await _cuentaRepository.Update(cuenta);
            await _cuentaRepository.SaveChangesAsync();
        }
    }
}
