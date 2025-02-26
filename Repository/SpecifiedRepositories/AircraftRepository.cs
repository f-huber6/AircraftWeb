using Database.Context;
using Database.Entities;
using Repository.Repository;

namespace Repository.SpecifiedRepositories;

public class AircraftRepository(AircraftContext context): ARepository<Aircraft>(context) { }