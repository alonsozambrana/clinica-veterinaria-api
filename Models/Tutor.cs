using System.ComponentModel.DataAnnotations;

namespace ClinicaVeterinariaAPI.Models;

public class Tutor
{
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;      
        public string Telefone { get; set; } = string.Empty;  
        public string? Email { get; set; }                     

        
        public List<Pet> Pets { get; set; } = new List<Pet>();
}
