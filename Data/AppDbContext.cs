using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Models;

namespace ProyectoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Viaje> Viajes => Set<Viaje>();

        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DriverVehiculo> DriverVehiculos => Set<DriverVehiculo>();
        public DbSet<Modelo> Modelos => Set<Modelo>();

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
            

            modelBuilder.Entity<Modelo>(entity =>
            {
                entity.HasKey(m => m.Id);
                entity.Property(m => m.Marca).IsRequired().HasMaxLength(100);
                entity.Property(m => m.Nombre).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Placa).IsRequired().HasMaxLength(20);
                entity.Property(v => v.Color).IsRequired().HasMaxLength(30);
                entity.Property(v => v.Estado).IsRequired().HasMaxLength(30);
            });
            modelBuilder.Entity<Modelo>()
                .HasOne(m => m.Vehiculo)
                .WithOne(v => v.Modelo)
                .HasForeignKey<Vehiculo>(v => v.ModeloId);
        }
    }
}
