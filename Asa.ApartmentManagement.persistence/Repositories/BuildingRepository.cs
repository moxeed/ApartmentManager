﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.BaseInfo.Domain;
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

        public Task AddApartmentAsync(ApartmentDto apartment)
        {
            throw new NotImplementedException();
        }

        public Task AddBuildingAsync(BuildingDto building)
        {
            throw new NotImplementedException();
        }

        public Task EditBuldingNameAsync(BuildingNameDto buildingName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApartmentDto>> GetBuildingApartments(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<BuildingDto> GetBuildingAsync(int buildingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BuildingDto>> GetBuildingsAsync()
        {
            throw new NotImplementedException();
        }
    }
}
