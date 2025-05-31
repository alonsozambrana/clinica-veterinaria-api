using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicaVeterinariaAPI.Models;

public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;       // Inicializado para evitar warning
    public string Especie { get; set; } = string.Empty;    // Inicializado para evitar warning
    public string? Raca { get; set; }                       // Raça pode ser opcional (nullable)

    // Foreign key
    public int TutorId { get; set; }
    public Tutor? Tutor { get; set; }   
}
