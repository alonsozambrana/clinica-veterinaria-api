using ClinicaVeterinariaAPI.Models;

namespace ClinicaVeterinariaAPI.Repositories.Interfaces;

public interface ITutorRepository
{
    Task<IEnumerable<Tutor>> GetAll();
    Task<Tutor?> GetById(int id);
    Task<Tutor> Add(Tutor tutor);
    Task<Tutor?> Update(int id, Tutor tutor);
    Task<bool> Delete(int id);
}
