using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entities;

[Table("MERCENARIES")]
public class Mercenary
{
    [Key, Column("MercenaryId"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MercenaryId { get; set; }
    
    [Column("Firstname"), Required, MaxLength(45)]
    public string? Firstname { get; set; }
    
    [Column("Lastname"), Required, MaxLength(45)]
    public string? Lastname { get; set; }
    
    [Column("BodySkills"), Required]
    public int BodySkills { get; set; }
    
    [Column("CombatSkills"), Required]
    public int CombatSkills { get; set; }
    
    public ICollection<AircraftCrews>? Crews { get; set; }
    
    public ICollection<MercenaryReputation>? Reputations { get; set; }
}