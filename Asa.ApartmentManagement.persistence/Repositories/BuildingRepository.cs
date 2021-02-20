using System;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly ApplicationDbContext _context;

        public BuildingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task AddBuildingAsync(BuildingDto building)
        {
            throw new NotImplementedException();
        }

        public Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            throw new NotImplementedException();
        }

        public Task<Building> GetBuildingAsync(int buildingId)
        {
            return _context.Building
                .Include(b => b.Apartments)
                .ThenInclude(a => a.Payers)
                .FirstOrDefaultAsync(b => b.BuildingId == buildingId);
        }
    }
}
