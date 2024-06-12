using System.ComponentModel.DataAnnotations;

namespace tutorial10.Models;

public class Prescription
{
    [Required]
    public Patient Patient { get; set; }
    
    [Required]
    public List<Medicament> Medicaments { get; set; }
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required] 
    public DateTime DueDate { get; set; }
    
    [Required]
    public int IdPatient { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
}