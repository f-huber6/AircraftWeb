using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

[Table("AIRCRAFTS")]
public class Aircraft
{
    [Column("AircraftId"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AircraftId { get; set; }
    
    [Column("Fuel"), Required]
    public int Fuel { get; set; }
    
    [Column("Speed"), Required]
    public int Speed { get; set; }
    
    [Column("Altitude"), Required]
    public int Altitude { get; set; }
    
    [Column("Name"), Required]
    public string? Name { get; set; }
    
    public AircraftSpecification? Specification { get; set; }
    
    [Column("SpecificationId"), Required]
    public int SpecificationId { get; set; }
    
    public ICollection<Compartment>? Compartments { get; set; }
    public ICollection<AircraftCrews>? Crew { get; set; }
    
}