using Microsoft.EntityFrameworkCore;
using Database.Entities;

namespace Database.Context;

public class AircraftContext: DbContext
{
    public AircraftContext(DbContextOptions<AircraftContext> options): base(options){}
    
    public DbSet<Aircraft> Aircrafts { get; set; }
    public DbSet<AircraftSpecification> AircraftSpecifications { get; set; }
    public DbSet<Compartment> Compartments { get; set; }
    public DbSet<Machinery> Machineries { get; set; }
    public DbSet<Mercenary> Mercenaries { get; set; }
    public DbSet<AircraftCrews> AircraftCrews { get; set; }
    public DbSet<CrimeSyndicate> CrimeSyndicates { get; set; }
    public DbSet<MercenaryReputation> MercenaryReputations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Aircraft>()
            .Navigation(a => a.Specification).AutoInclude();
        modelBuilder.Entity<Aircraft>()
            .Navigation(a => a.Compartments).AutoInclude();
        modelBuilder.Entity<Compartment>()
            .Navigation(c => c.Machineries).AutoInclude();
        
        modelBuilder.Entity<AircraftCrews>()
            .HasKey(ac => new { ac.AircraftId, ac.MercenaryId });
        
        modelBuilder.Entity<MercenaryReputation>()
            .HasKey(mr => new {mr.SyndicateId, mr.MercenaryId});
        
        modelBuilder.Entity<Aircraft>()
            .HasOne(a => a.Specification)
            .WithMany()
            .HasForeignKey(a => a.SpecificationId);
        
        modelBuilder.Entity<Compartment>()
            .HasOne(c => c.Aircraft)
            .WithMany(a => a.Compartments)
            .HasForeignKey(c => c.AircraftId);
        
        modelBuilder.Entity<Machinery>()
            .HasOne(m => m.Compartment)
            .WithMany(c => c.Machineries)
            .HasForeignKey(m => m.CompartmentId);
        
        modelBuilder.Entity<AircraftCrews>()
            .HasOne(ac => ac.Aircraft)
            .WithMany(a => a.Crew)
            .HasForeignKey(ac => ac.AircraftId);
        
        modelBuilder.Entity<AircraftCrews>()
            .HasOne(ac => ac.Mercenary)
            .WithMany(m => m.Crews)
            .HasForeignKey(ac => ac.MercenaryId);
        
        modelBuilder.Entity<MercenaryReputation>()
            .HasOne(mr => mr.CrimeSyndicate)
            .WithMany()
            .HasForeignKey(mr => mr.SyndicateId);
        
        modelBuilder.Entity<MercenaryReputation>()
            .HasOne(mr => mr.Mercenary)
            .WithMany(m => m.Reputations)
            .HasForeignKey(mr => mr.MercenaryId);
        
        modelBuilder.Entity<Machinery>()
            .HasDiscriminator<string>("MachineryType")
            .HasValue<Weapon>("Weapon")
            .HasValue<EnergySystem>("EnergySystem")
            .HasValue<EnvironmentalSystem>("EnvironmentalSystem");
    }
}