using ClinicaVeterinariaAPI.Data;
using ClinicaVeterinariaAPI.Models;
using ClinicaVeterinariaAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Repositories;

public class TutorRepository : ITutorRepository
{
    private readonly AppDbContext _context;
    public TutorRepository(AppDbContext context) => _context = context;

    public async Task<Tutor> Add(Tutor tutor)
    {
        _context.Tutores.Add(tutor);
        await _context.SaveChangesAsync();
        return tutor;
    }

    public async Task<bool> Delete(int id)
    {
        var tutor = await _context.Tutores.FindAsync(id);
        if (tutor == null) return false;
        _context.Tutores.Remove(tutor);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Tutor>> GetAll() =>
        await _context.Tutores.Include(t => t.Pets).ToListAsync();

    public async Task<Tutor?> GetById(int id) =>
        await _context.Tutores.Include(t => t.Pets).FirstOrDefaultAsync(t => t.Id == id);

    public async Task<Tutor?> Update(int id, Tutor tutor)
    {
        var existing = await _context.Tutores.FindAsync(id);
        if (existing == null) return null;

        existing.Nome = tutor.Nome;
        existing.Telefone = tutor.Telefone;
        existing.Email = tutor.Email;

        await _context.SaveChangesAsync();
        return existing;
    }
}
