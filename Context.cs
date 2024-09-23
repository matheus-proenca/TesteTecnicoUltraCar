using Microsoft.EntityFrameworkCore;
using Testetecnico_Ultracar.Models;

namespace Testetecnico_Ultracar
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Peca> Peca { get; set; } = null!;
        public DbSet<Orcamento> Orcamento { get; set; } = null!;
        public DbSet<Estoque> Estoque { get; set; } = null!;
        public DbSet<Entrega> Entrega { get; set; } = null!;
        public DbSet<QuantidadePeca> QuantidadePeca { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=testetecnico;Username=usuario;Password=password");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Estoque>().HasOne(e => e.Entrega).WithOne(e => e.Estoque).HasForeignKey<Estoque>(k => k.EntregaId);
            modelBuilder.Entity<Entrega>().HasOne(p => p.Peca).WithOne(e => e.Entrega).HasForeignKey<Entrega>(k => k.PecaId);
            modelBuilder.Entity<Entrega>().HasOne(o => o.Orcamento).WithOne(e => e.Entrega).HasForeignKey<Entrega>(k => k.OrcamentoId);
            modelBuilder.Entity<QuantidadePeca>().HasOne(q => q.Orcamento).WithOne(o => o.QuantidadePeca)
                .HasForeignKey<QuantidadePeca>(k => k.OrcamentoId);
            modelBuilder.Entity<QuantidadePeca>().HasOne(q => q.Peca).WithOne(p => p.QuantidadePeca)
                .HasForeignKey<QuantidadePeca>(k => k.PecaId);

            modelBuilder.Entity<Peca>().HasKey(p => p.PecaId);
            modelBuilder.Entity<Peca>().Property(p => p.PecaId).ValueGeneratedOnAdd();
        }
    }
}
