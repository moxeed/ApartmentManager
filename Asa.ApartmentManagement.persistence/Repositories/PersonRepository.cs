﻿using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Persistence.Context;
using System;
using Asa.ApartmentManagement.Persistence.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Asa.ApartmentManagement.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly BaseInfoDbContext _baseInfoContext;
        public PersonRepository(BaseInfoDbContext context)
        {
            _baseInfoContext = context;
        }

        public async Task AddOwnerTenantAsync(OwnerTenantDto owner)
        {
            var entry = owner.ToEntry();
            await _baseInfoContext.OwnerTenants.AddAsync(entry);
            await _baseInfoContext.SaveChangesAsync();
            owner.OwnerTenantId = entry.OwnerTenantId;
        }

        public async Task AddPersongAsync(PersonDto person)
        {
            var entry = person.ToEntry();
            await _baseInfoContext.PersonInfos.AddAsync(entry);
            await _baseInfoContext.SaveChangesAsync();
            person.PersonId = entry.PersonId;
        }

        public async Task EditOwnerTenantAsync(OwnerTenantDto owner)
        {
            var ownertenant = await _baseInfoContext.OwnerTenants.AsNoTracking().FirstOrDefaultAsync(b => b.OwnerTenantId == owner.OwnerTenantId);
            if (ownertenant == null)
            {
                throw new NullReferenceException($"Cannot Find OwnerTenant with {owner.OwnerTenantId} id");
            }
            var entry = owner.ToEntry();
            entry.PersonId = ownertenant.PersonId;
            entry.ApartmentId = ownertenant.ApartmentId;
            _baseInfoContext.OwnerTenants.Update(entry);
            try
            {
                await _baseInfoContext.SaveChangesAsync();
            }
            catch (Exception e) 
            {
            }
        }

        public async Task EditPersongAsync(PersonDto person)
        {
            if (!_baseInfoContext.PersonInfos.Any(c => c.PersonId == person.PersonId))
                throw new NullReferenceException($"Cannot Find Person with {person.PersonId} id");
            var entry = person.ToEntry();
            _baseInfoContext.PersonInfos.Update(entry);
            await _baseInfoContext.SaveChangesAsync();
        }

        public async Task<OwnerTenantDto> GetCurrentOwnerTenantById(int ownertenantId)
        {
           var ownertenant =  await _baseInfoContext.OwnerTenants.AsNoTracking().FirstOrDefaultAsync(b => b.OwnerTenantId == ownertenantId);
           var ownertenantDto = ownertenant.ToDto();
           return ownertenantDto;
        }

        public async Task<IEnumerable<PersonDto>> GetPersonsAsync()
        {
            var persons = await _baseInfoContext.PersonInfos.ToListAsync();
            return persons.Project();
        }
    }
}
