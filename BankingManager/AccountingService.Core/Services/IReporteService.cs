using AccountingService.Core.DTOs;

namespace AccountingService.Core.Services
{
    public interface IReporteService
    {
        Task <EstadoCuentaDto> GetEstadoCuenta (int clienteId, DateTime fechaInicio, DateTime fechaFin);
    }
}
