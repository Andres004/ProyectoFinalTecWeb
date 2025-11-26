using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Viaje> Viajes => Set<Viaje>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Origen).IsRequired().HasMaxLength(100);
                entity.Property(v => v.Destino).IsRequired().HasMaxLength(100);
                entity.Property(v => v.FechaSalida).IsRequired();
                entity.Property(v => v.Precio).IsRequired().HasColumnType("decimal(18,2)");
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(50);
            });
        }
    }
}
