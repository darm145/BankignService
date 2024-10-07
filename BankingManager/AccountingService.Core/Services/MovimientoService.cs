using AccountingService.Core.DTOs;
using AccountingService.Core.Models;
using AccountingService.Core.Repositories;
using AccountingService.Core.Exceptions;

namespace AccountingService.Core.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MovimientoService(IMovimientoRepository movimientoRepository, IUnitOfWork unitOfWork)
        {
            _movimientoRepository = movimientoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Delete(int id)
        {
            await _movimientoRepository.Delete(id);
            await _movimientoRepository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movimiento>> GetAll()
        {
            return await _movimientoRepository.GetAll();
        }

        public async Task<Movimiento> GetById(int id)
        {
            return await _movimientoRepository.GetById(id);
        }

        public async Task Save(MovimientoDto movimiento)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var cuenta = await _unitOfWork.Cuentas.GetById(movimiento.NumeroCuenta);
                if (cuenta == null)
                {
                    throw new Exception($"cuenta con ID {movimiento.NumeroCuenta} no encontrado.");
                }
                decimal nuevoSaldo = cuenta.SaldoInicial + movimiento.Valor;
                if (nuevoSaldo < 0)
                {
                    throw new FailedOperationException("Saldo no disponible");
                }
                cuenta.SaldoInicial = nuevoSaldo;
                Movimiento movimientoFinal= new Movimiento
                {
                    Fecha = movimiento.Fecha,
                    MovimientoId = movimiento.MovimientoId, 
                    NumeroCuenta= movimiento.NumeroCuenta,
                    Saldo = nuevoSaldo,
                    TipoMovimiento = movimiento.TipoMovimiento,
                    Valor = movimiento.Valor
                };
                await _unitOfWork.Cuentas.Update(cuenta);
                await _unitOfWork.Movimientos.Save(movimientoFinal);
                await _unitOfWork.SaveAsync();
                await _unitOfWork.CommitTransactionAsync();


            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync(); 
                throw;

            }
        }

        public async Task Update(Movimiento Movimiento)
        {
            await _movimientoRepository.Update(Movimiento);
            await _movimientoRepository.SaveChangesAsync();
        }
    }
}
