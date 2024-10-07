using Microsoft.EntityFrameworkCore;
using AccountingService.Core.Models;

namespace AccountingService.Infrastructure.Data
{
    public class AccountingDbContext : DbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options) : base(options) { }
        public DbSet<Cuenta> Cuentas { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cuenta>().HasKey(c => c.NumeroCuenta);
            modelBuilder.Entity<Movimiento>().HasKey(m => m.MovimientoId);
            modelBuilder.Entity<Movimiento>().HasOne<Cuenta>()
                .WithMany(c => c.Movimientos)
                .HasForeignKey(m => m.NumeroCuenta);
        }
    }
}

