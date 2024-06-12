using System.ComponentModel.DataAnnotations;

namespace tutorial10.Models;

public class Medicament
{
   [Required]
   [MaxLength (100)]
    public String Name { get; set; } 
    
    [Required]
    [MaxLength (100)]
    public String Description { get; set; }
    
    [Required]
    [MaxLength (100)]
    public String Type { get; set; }
}