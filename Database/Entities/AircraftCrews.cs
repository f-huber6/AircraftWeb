using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

[Table("AIRCRAFT_CREW_JT")]
public class AircraftCrew
{
    public Aircraft? Aircraft { get; set; }
    
    [Column("AircraftId"), Required]
    public int AircraftId { get; set; }
    
    public Mercenary? Mercenary { get; set; }
    
    [Column("MercenaryId"), Required]
    public int MercenaryId { get; set; }
    
    [Column("JoinedAt"), Required]
    public DateTime JoinedAt { get; set; }
}