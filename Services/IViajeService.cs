using ProyectoFinal.Models.DTOS;

namespace ProyectoFinal.Services
{
    public interface IViajeService
    {
        Task<int> CreateAsync(CreateViajeDto dto);

        //Task<ViajePasajeroDto?> GetPasajeroAsync(int id);
    }
}
