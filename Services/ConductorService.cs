using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;
using ProyectoFinal.Repositories;

namespace ProyectoFinal.Services
{
    public class ConductorService : IConductorService
    {
        private readonly IConductorRepository _conductores;
        private readonly IConfiguration _configuration;

        public ConductorService(IConductorRepository conductores, IConfiguration configuration)
        {
            _conductores = conductores;
            _configuration = configuration;
        }


        public async Task<Guid> CreateAsync(CreateConductorDto dto)
        {
            var entity = new Conductor { Nombre = dto.Nombre, Licencia = dto.Licencia, Telefono = dto.Telefono, Email = dto.Email };
            await _conductores.AddAsync(entity);
            await _conductores.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<string> RegisterAsync(RegisterConductorDto dto)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            var conductor = new Conductor
            {
                Email = dto.Email,
                Nombre = dto.Nombre
            };
            await _conductores.AddAsync(conductor);
            return conductor.Id.ToString();
        }

    }
}
