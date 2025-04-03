using Microsoft.EntityFrameworkCore;
using TrabalhoAlmir.Model;

namespace TrabalhoAlmir.Infraestrutura {
    public class ConnectionContext : DbContext {

        public DbSet<Veiculos> Veiculos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432;Database=trabalho;" +
                "User Id=postgres;" +
                "Password=123;");

    }
}
