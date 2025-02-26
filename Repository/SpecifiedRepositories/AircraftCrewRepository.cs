using Database.Context;
using Database.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repository;

namespace Repository.SpecifiedRepositories;

public class AircraftCrewRepository(AircraftContext context) : ARepository<AircraftCrews>(context)
{
    private AircraftContext _context = context;
    
    public override Task<List<AircraftCrews>> ReadAllAsync()
    {
        return _context.AircraftCrews
            .Include(s => s.Aircraft)
            .Include(s => s.Mercenary)
            .ToListAsync();
    }
}
