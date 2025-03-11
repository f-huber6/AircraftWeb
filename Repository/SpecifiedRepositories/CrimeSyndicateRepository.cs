using Database.Context;
using Database.Entities;
using Repository.Repository;

namespace Repository.SpecifiedRepositories;

public class CrimeSyndicateRepository(AircraftContext context): ARepository<CrimeSyndicate>(context)
{
    
}