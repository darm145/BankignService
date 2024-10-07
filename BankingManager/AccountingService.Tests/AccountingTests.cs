using AccountingService.Core.DTOs;
using AccountingService.Core.Exceptions;
using AccountingService.Core.Models;
using AccountingService.Core.Models.Enums;
using AccountingService.Core.Services;
using AccountingService.Infrastructure.Data;
using AccountingService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
namespace AccountingService.Tests
{
    public class AccountingTests
    {
        private readonly AccountingDbContext _context;
        private readonly CuentaService _cuentaService;
        private readonly MovimientoService _movimientoService;

        public AccountingTests()
        {
            var options = new DbContextOptionsBuilder<AccountingDbContext>()
                .UseInMemoryDatabase(databaseName: "TestAccountingDb").ConfigureWarnings(warnings =>
                    warnings.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;
            _context= new AccountingDbContext(options);
            var cuentaRepository = new CuentaRepository(_context);
            var movimientoRepository = new MovimientoRepository(_context);
            var UnitOfWork = new UnitOfWork(_context,cuentaRepository, movimientoRepository);
            _cuentaService = new CuentaService(cuentaRepository);
            _movimientoService = new MovimientoService(movimientoRepository, UnitOfWork);
        }

        [Fact]
        public async void Debe_Crear_y_Obtener_Cuenta()
        {
            var cuenta = new PostCuentaDto
            {
                Estado = true,
                NumeroCuenta = "1",
                SaldoInicial = 500,
                TipoCuenta = TipoCuenta.Ahorros,
                ClienteId= 1
            };
            await _cuentaService.Save(cuenta);
            var cuentaGuardarda = await _cuentaService.GetById("1");
            Assert.NotNull(cuentaGuardarda);
            Assert.Equal(cuenta.NumeroCuenta, cuentaGuardarda.NumeroCuenta);
        }
        [Fact]
        public async void Debe_Actualizar_Saldo_Correctamente()
        {
            var cuenta = new PostCuentaDto
            {
                Estado = true,
                NumeroCuenta = "2",
                SaldoInicial = 500,
                TipoCuenta = TipoCuenta.Ahorros,
                ClienteId = 2
            };
            await _cuentaService.Save(cuenta);
            var movimiento = new MovimientoDto
            {
                Fecha = DateTime.Now,
                MovimientoId = 1,
                NumeroCuenta = "2",
                TipoMovimiento = TipoMovimiento.Deposito,
                Valor = 500
            };
            await _movimientoService.Save(movimiento);
            var cuentaActualizada = await _cuentaService.GetById("2");
            Assert.NotNull(cuentaActualizada);
            Assert.Equal(1000, cuentaActualizada.SaldoInicial);
        }

        [Fact]
        public async void Debe_Fallar_Saldo_Insuficiente()
        {
            var cuenta = new PostCuentaDto
            {
                Estado = true,
                NumeroCuenta = "3",
                SaldoInicial = 500,
                TipoCuenta = TipoCuenta.Ahorros,
                ClienteId = 3
            };
            await _cuentaService.Save(cuenta);
            var movimiento = new MovimientoDto
            {
                Fecha = DateTime.Now,
                MovimientoId = 1,
                NumeroCuenta = "3",
                TipoMovimiento = TipoMovimiento.Retiro,
                Valor = -600
            };
            
            var exception = await Assert.ThrowsAsync<FailedOperationException>(() => _movimientoService.Save(movimiento));
            Assert.Equal("Saldo no disponible", exception.Message);
        }



    }
}