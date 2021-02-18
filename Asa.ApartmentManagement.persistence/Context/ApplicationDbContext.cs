using Asa.ApartmentManagement.Core.ChargeCalculation;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Building> Building { get; set; }
    }
}
