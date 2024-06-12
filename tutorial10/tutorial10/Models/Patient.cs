using System.ComponentModel.DataAnnotations;

namespace tutorial10.Models;

public class Patient
{
    [Required]
    public int IdPatient { get; set; } //potrzebne do wstawienia pacjenta, bo w przypadku
    //gdy istnieje to nie będziemy używać tego pola tylko do znaleziena pacjenta
    [Required]
    [MaxLength (100)]
    public String FirstName { get; set; }
    [Required]
    [MaxLength (100)]
    public String LastName { get; set; }
    [Required]
    public DateTime Birthdate { get; set; }
    
}