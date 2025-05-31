using ClinicaVeterinariaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinariaAPI.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Tutor> Tutores => Set<Tutor>();
    public DbSet<Pet> Pets => Set<Pet>();
}