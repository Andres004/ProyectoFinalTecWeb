using ProyectoFinal.Models;
using ProyectoFinal.Models.DTOS;
using ProyectoFinal.Models.DTOS.ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IConductorService
    {
        //Authentication
        Task<Guid> CreateAsync(CreateConductorDto dto);
        Task<string> RegisterAsync(RegisterConductorDto dto);

        //CRUD
        Task<IEnumerable<Conductor>> GetAll();
        Task<Conductor> GetOne(Guid id);
        Task<Conductor> UpdateConductor(UpdateConductorDto dto, Guid id);
        Task DeleteConductor(Guid id);
     
    }
}
