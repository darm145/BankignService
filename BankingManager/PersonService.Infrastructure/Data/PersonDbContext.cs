using Microsoft.EntityFrameworkCore;
using PersonService.Core.Models;

namespace PersonService.Infrastructure.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<Cliente> Clientes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cliente>().HasKey(c => c.Id);
        }
    }
}
