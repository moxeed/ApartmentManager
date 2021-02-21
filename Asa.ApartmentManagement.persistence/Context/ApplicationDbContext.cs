using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Context
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext() : base() { }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<BuildingInfo> Building { get; set; }
    }
}
