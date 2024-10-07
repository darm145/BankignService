using AccountingService.Core.Models.Enums;

namespace AccountingService.Core.DTOs
{
    public class PostCuentaDto
    {
        public string NumeroCuenta { get; set; }
        public TipoCuenta TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }
    }
}
