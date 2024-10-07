using AccountingService.Core.DTOs;
using AccountingService.Core.Repositories;

namespace AccountingService.Core.Services
{
    public class ReporteService : IReporteService
    {
        private readonly ICuentaRepository _cuentaRepository;
        public ReporteService(ICuentaRepository cuentaRepository)
        {
            _cuentaRepository = cuentaRepository;
        }

        public async Task<EstadoCuentaDto> GetEstadoCuenta(int clienteId,DateTime fechaInicio,DateTime fechaFin)
        {
            var cuentas = await _cuentaRepository.GetClientAccounts(clienteId);
            foreach (var cuenta in cuentas) {
                cuenta.Movimientos = cuenta.Movimientos.Where(m => m.Fecha >= fechaInicio && m.Fecha <= fechaFin).ToList();
            }

            return new EstadoCuentaDto
            {
                Cliente = clienteId,
                Cuentas = cuentas.Select(c => new CuentaDto
                {
                    Movimientos = c.Movimientos,
                    Estado = c.Estado,
                    NumeroCuenta = c.NumeroCuenta,
                    SaldoInicial = c.SaldoInicial,
                    TipoCuenta = c.TipoCuenta
                }).ToList()
            };
            
            
        }
    }
}
