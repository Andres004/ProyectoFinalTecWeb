using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculos;

        public VehiculoService(IVehiculoRepository vehiculos)
        {
            _vehiculos = vehiculos;
        }

        public async Task<Guid> CreateAsync(CreateVehicleDto dto)
        {
            var exists = await _vehiculos.ExistsPlacaAsync(dto.Placa);
            if (exists)
                throw new InvalidOperationException("Ya existe un vehículo con esa placa.");

            var vehiculo = new Vehiculo
            {
                Id = Guid.NewGuid(),
                Placa = dto.Placa,
                Estado = "Activo"
            };

            await _vehiculos.AddAsync(vehiculo);
            await _vehiculos.SaveChangesAsync();

            return vehiculo.Id;
        }

        public Task<Vehiculo?> GetByIdAsync(Guid id)
            => _vehiculos.GetVehiculoAsync(id);

        public async Task<IEnumerable<Vehiculo>> GetAllAsync()
        {

            throw new NotImplementedException();
        }

        public async Task<bool> UpdateAsync(Guid id, UpdateVehicleDto dto)
        {
            var vehiculo = await _vehiculos.GetVehiculoAsync(id);
            if (vehiculo == null) return false;


            if (!string.IsNullOrWhiteSpace(dto.Estado))
                vehiculo.Estado = dto.Estado;


            await _vehiculos.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var vehiculo = await _vehiculos.GetVehiculoAsync(id);
            if (vehiculo == null) return false;


            vehiculo.Estado = "Inactivo";
            await _vehiculos.SaveChangesAsync();
            return true;
        }
    }
}
