using AccountingService.Core.Models.Enums;

namespace AccountingService.Core.Models
{
    public class Movimiento
    {
        public int MovimientoId {  get; set; }
        public DateTime Fecha { get; set; }
        public TipoMovimiento TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public string NumeroCuenta { get; set; }

    }
}
