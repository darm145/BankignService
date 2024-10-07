using AccountingService.Core.Models;

namespace AccountingService.Core.DTOs
{
    public class EstadoCuentaDto
    {
        public int Cliente { get; set; }
        public ICollection<CuentaDto> Cuentas { get; set; }
    }
}
