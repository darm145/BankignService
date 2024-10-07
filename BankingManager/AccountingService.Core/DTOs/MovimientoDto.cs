using AccountingService.Core.Models.Enums;

namespace AccountingService.Core.DTOs
{
    public class MovimientoDto
    {
        public int MovimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public string NumeroCuenta { get; set; }
    }
}
