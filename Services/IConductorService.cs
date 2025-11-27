using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IConductorService
    {
        Task<Guid> CreateAsync(CreateConductorDto dto);
        Task<string> RegisterAsync(RegisterConductorDto dto);
    }
}
