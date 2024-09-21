using Microsoft.EntityFrameworkCore;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar
{
    public class Context : DbContext
    {
        public DbSet<Peca> Pecas { get; set; } = null!;
        public DbSet<Orcamento> Orcamentos { get; set; } = null!;
        public DbSet<Estoque> Estoques { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testetecnico;Username=usuario;Password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estoque>().HasOne(e => e.Orcamento).WithOne(o => o.Estoque).HasForeignKey<Estoque>(k => k.OrcamentoId);
            modelBuilder.Entity<Estoque>().HasOne(e => e.Peca).WithOne(o => o.Estoque).HasForeignKey<Estoque>(k => k.PecaId);
            modelBuilder.Entity<Orcamento>().HasMany(o => o.Peca).WithOne(p => p.Orcamento).HasForeignKey(k => k.PecaId);
        }
    }
}
