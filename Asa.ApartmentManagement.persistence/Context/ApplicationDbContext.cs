using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ApplicationDbContext : DbContext , IUnitOfwork
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Building> Building { get; set; }

        public IBuildingRepository BuildingRepository => new BuildingRepository(this);
    }
}
