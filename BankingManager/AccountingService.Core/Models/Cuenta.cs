using AccountingService.Core.Models.Enums;

namespace AccountingService.Core.Models
{
    public class Cuenta
    {
        public string NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }  
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
