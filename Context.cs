using Microsoft.EntityFrameworkCore;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
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
            modelBuilder.Entity<Estoque>().HasMany(e => e.Entregas).WithOne(e => e.Estoque).HasForeignKey(k => k.EntregaId);
            modelBuilder.Entity<Estoque>().HasOne(p => p.Peca).WithOne(o => o.Estoque).HasForeignKey<Estoque>(k => k.PecaId);
            modelBuilder.Entity<Orcamento>().HasMany(o => o.Peca).WithOne(p => p.Orcamento).HasForeignKey(k => k.PecaId);
            modelBuilder.Entity<Entrega>().HasMany(p => p.Peca).WithOne(e => e.Entrega).HasForeignKey(k => k.PecaId);
            modelBuilder.Entity<Entrega>().HasOne(o => o.Orcamento).WithOne(e => e.Entrega).HasForeignKey<Entrega>(k => k.OrcamentoId);

        }
    }
}
