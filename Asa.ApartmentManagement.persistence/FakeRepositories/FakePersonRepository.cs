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
        private readonly ICollection<PersonDto> _persons;

        public async Task AddPersongAsync(PersonDto person)
        {
            person.PersonId = _persons.Max(p => p.PersonId) + 1;
            _persons.Add(person);
        }

        public async Task EditPersongAsync(PersonDto person)
        {
            var entry = _persons.FirstOrDefault(p => p.PersonId == person.PersonId);
            if (entry is null) throw new NullReferenceException();
            _persons.Remove(entry);
            _persons.Add(person);
        }
    }
}
