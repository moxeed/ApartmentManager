using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.FakeRepositories
{


    public class FakePersonRepository : IPersonRepository
    {

        private readonly ICollection<OwnerTenantDto> _ownertenants;
        private readonly ICollection<PersonDto> _persons;



        public FakePersonRepository()
        {
            _persons = new List<PersonDto>();
            PersonDto building = new PersonDto { PersonId = 0, Name = "Test", LastName="TestAgain", PhoneNumber = "0999282618"};
            _persons.Add(building);
            _ownertenants = new List<OwnerTenantDto>();
        }

        public async Task AddOwnerTenant(OwnerTenantDto owner)
        {
            owner.OwnerTenantId = _ownertenants.Max(a => a.OwnerTenantId) + 1;
            _ownertenants.Add(owner);
        }

        public Task AddOwnerTenantAsync(OwnerTenantDto owner)
        {
            throw new NotImplementedException();
        }

        public async Task AddPersongAsync(PersonDto person)
        {
            person.PersonId = _persons.Max(p => p.PersonId) + 1;
            _persons.Add(person);
        }

        internal async Task<PersonDto> GetPersonById(int personId)
        {
            return _persons.FirstOrDefault(p=> p.PersonId == personId);
        }

        public Task EditOwnerTenantAsync(OwnerTenantDto owner)
        {
            throw new NotImplementedException();
        }

        public async Task EditPersongAsync(PersonDto person)
        {
            var entry = _persons.FirstOrDefault(p => p.PersonId == person.PersonId);
            if (entry is null) throw new NullReferenceException();
            _persons.Remove(entry);
            _persons.Add(person);

        }

        public async Task<IEnumerable<OwnerTenantDto>> GetAllCurrentOwnerTenants()
        {
            return _ownertenants;   
        }

        public Task<OwnerTenantDto> GetCurrentOwnerTenantById(int ownertenantId)
        {
            throw new NotImplementedException();
        }
    }
}



