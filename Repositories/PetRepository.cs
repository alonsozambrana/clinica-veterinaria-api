using ClinicaVeterinariaAPI.Data;
using ClinicaVeterinariaAPI.Models;
using ClinicaVeterinariaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Repositories;

public class PetRepository : IPetRepository
{
    private readonly AppDbContext _context;
    public PetRepository(AppDbContext context) => _context = context;

    public async Task<Pet> Add(Pet pet)
    {
        _context.Pets.Add(pet);
        await _context.SaveChangesAsync();
        return pet;
    }

    public async Task<bool> Delete(int id)
    {
        var pet = await _context.Pets.FindAsync(id);
        if (pet == null) return false;
        _context.Pets.Remove(pet);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Pet>> GetAll() =>
        await _context.Pets.Include(p => p.Tutor).ToListAsync();

    public async Task<Pet?> GetById(int id) =>
        await _context.Pets.Include(p => p.Tutor).FirstOrDefaultAsync(p => p.Id == id);

    public async Task<Pet?> Update(int id, Pet pet)
    {
        var existing = await _context.Pets.FindAsync(id);
        if (existing == null) return null;

        existing.Nome = pet.Nome;
        existing.Especie = pet.Especie;
        existing.Raca = pet.Raca;
        existing.TutorId = pet.TutorId;

        await _context.SaveChangesAsync();
        return existing;
    }
}
