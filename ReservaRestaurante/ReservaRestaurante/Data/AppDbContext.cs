using Microsoft.EntityFrameworkCore;
using ReservaRestaurante.Models;

namespace ReservaRestaurante.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Reserva> Reservas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>().HasData(
     new Cliente { IdCliente = 1, Nome = "Mario Silva", Telefone = "11945687153", },
     new Cliente { IdCliente = 2, Nome = "Carla Nogueira", Telefone = "14975852146", },
     new Cliente { IdCliente = 3, Nome = "Elis Regiane", Telefone = "11916325874" }
     );
    }

}
