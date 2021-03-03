using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;

namespace Asa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class PersonManager : IPersonManager
    {


        private readonly IPersonRepository _personRepository;
        private readonly IBuildingManager _buildingManager;


        public PersonManager(IPersonRepository repository , IBuildingManager buildingManager)
        {
            _personRepository = repository;
            _buildingManager = buildingManager;
        }
  
        private void ValidatePerson(PersonDto person)
        {
            
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new ValidationException(ErrorCodes.Invalid_Person_Name, $"Person name cannot be neither empty");
            }
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ValidationException(ErrorCodes.Invalid_Person_LastName, $"Person LastName cannot be Empty");
            }
         
            Regex re = new Regex(@"^(\+98|0)9\d{9}$");
            if (!(re.Match(person.PhoneNumber).Success))
            {
                throw new ValidationException(ErrorCodes.Invalid_Phone_Number, $"Phone number is not Valid");
            }
        }

        private async Task ValidateOwnerTenantAsync(OwnerTenantDto ownertenant)
        {
            if (ownertenant.To < ownertenant.From)
            {
                throw new ValidationException(ErrorCodes.Invalid_Entrence_Time, $"Date entrance should not be greater than Exit Time ");
            }


            var buildingId = await _buildingManager.GetBuildingIdOfOwnerTenant(ownertenant.ApartmentId);
            var allCurrentOwners = await _buildingManager.GetAllCurrentOwnerTenants(buildingId);

            foreach (var ot in allCurrentOwners)
            {
                if (ot.ApartmentId == ownertenant.ApartmentId)
                {
                    throw new ValidationException(ErrorCodes.Apartment_Is_Taken, $"This apartment Is occupied");
                }
            }

            if (!(ownertenant.IsOwner))
                if (ownertenant.OccupantCount < 1)
                {
                    throw new ValidationException(ErrorCodes.OccupantCount_Error, $"The counts of the occupant should not be smaller than 1");
                }

        }

        public async Task AddPersonAsync(PersonDto person)
        {
            ValidatePerson(person);
            await _personRepository.AddPersongAsync(person);
        }

        public Task EditPersonAsync(PersonDto person)
        {
            ValidatePerson(person);
            return _personRepository.EditPersongAsync(person);
        }

        public async Task AddOwnerTenantAsync(OwnerTenantDto ownerTenant )
        {
            await ValidateOwnerTenantAsync(ownerTenant);
            await _personRepository.AddOwnerTenantAsync(ownerTenant);
        }

        public async Task EditOwnerTenantAsync(OwnerTenantDto ownerTenant)
        {
            var prevOwnerTenant = await GetCurrentOwnerTenantById(ownerTenant.OwnerTenantId);

            if (ownerTenant.OccupantCount != prevOwnerTenant.OccupantCount)
            {
                ownerTenant.From = DateTime.Now;
                prevOwnerTenant.To = DateTime.Now;
                await _personRepository.AddOwnerTenantAsync(ownerTenant);
                if (prevOwnerTenant.From != ownerTenant.From)
                { 
                    await _personRepository.EditOwnerTenantAsync(ownerTenant);
                }
 
            }
            await _personRepository.EditOwnerTenantAsync(ownerTenant);
        }

        public Task<OwnerTenantDto> GetCurrentOwnerTenantById(int ownertenantId)
        {
             return  _personRepository.GetCurrentOwnerTenantById(ownertenantId);
        }

        public async Task<IEnumerable<PersonDto>> GetPersonsAsync()
        {
            return await _personRepository.GetPersonsAsync();
        }
    }
}


