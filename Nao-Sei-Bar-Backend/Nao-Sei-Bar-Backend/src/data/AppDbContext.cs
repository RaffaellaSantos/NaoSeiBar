using Microsoft.EntityFrameworkCore;
using Nao_Sei_Bar_Backend.src.data.entities;
using NaoSeiBar.src.data.entities;

namespace Nao_Sei_Bar_Backend.src.data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Atendente> Atendentes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Financeiro> Financeiros { get; set; }
        public DbSet<Fornecedor> Fornecedors { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RH> RHs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
