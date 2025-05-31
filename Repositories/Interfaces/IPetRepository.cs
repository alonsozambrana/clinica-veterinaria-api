using ClinicaVeterinariaAPI.Models;

namespace ClinicaVeterinariaAPI.Repositories.Interfaces;

public interface IPetRepository
{
    Task<IEnumerable<Pet>> GetAll();
    Task<Pet?> GetById(int id);
    Task<Pet> Add(Pet pet);
    Task<Pet?> Update(int id, Pet pet);
    Task<bool> Delete(int id);
}
