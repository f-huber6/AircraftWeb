using Database.Context;
using Database.Entities;
using Repository.Repository;

namespace Repository.SpecifiedRepositories;

public class MercenaryRepository(AircraftContext context): ARepository<Mercenary>(context) { }