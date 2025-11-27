using ProyectoFinal.Models;

namespace ProyectoFinal.Repositories
{
    public interface IConductorRepository
    {
        Task<Conductor?> GetByEmailAddress(string email);
        Task AddAsync(Conductor conductor);
        Task UpdateAsync(Conductor conductor);


        Task<Conductor?> GetViajesAsync(Guid id);
        Task<bool> ExistsAsync(Guid id);
        Task<int> SaveChangesAsync();
        
        Task<IEnumerable<Conductor>> GetAll();

        /*
         Task<IEnumerable<Hospital>> GetAll();
        Task<Hospital> GetOne(Guid id);
        Task Add(Hospital hospital);
        Task Update(Hospital hospital);
        Task Delete(Hospital hospital);
         */
    }
}
