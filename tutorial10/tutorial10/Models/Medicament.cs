using System.ComponentModel.DataAnnotations;

namespace tutorial10.Models;

public class Medicament
{
    [Required]
    public int IdMedicament { get; set; }
    
    [Required]
   [MaxLength (100)]
    public String Name { get; set; } //parametr dla realizmu bo w rzeczywistości nigdzie nie wstawiamy go do bazy danych
    
    [Required]
    [MaxLength (100)]
    public String Details { get; set; }
    
    public int Dose { get; set; }
}