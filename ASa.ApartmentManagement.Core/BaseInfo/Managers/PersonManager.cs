using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.Common;
using Asa.ApartmentManagement.Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Asa.ApartmentManagement.Core.BaseInfo.Managers
{
    public class PersonManager : IPersonManager
    {


        private readonly IPersonManager _repository;


        public PersonManager(IPersonManager repository)
        {
            _repository = repository;
        }

        private static void ValidatePerson(PersonDto person)
        {
            //Name andn LastName should not be 
            if (string.IsNullOrWhiteSpace(person.Name))
            {
                throw new ValidationException(ErrorCodes.Invalid_Person_Name, $"Person name cannot be neither empty");
            }
            if (string.IsNullOrWhiteSpace(person.LastName))
            {
                throw new ValidationException(ErrorCodes.Invalid_Person_LastName, $"Person LastName cannot be Empty");
            }
            //Phone number check (\+98|0)?9\d{9}
            Regex re = new Regex(@"(\+98|0)?9\d{9}");
            if (re.Match(person.PhoneNumber).Success)
            {
                throw new ValidationException(ErrorCodes.Invalid_Phone_Number, $"Phone number is not Valid");
            }
        }

        public async Task AddPersonAsync(PersonDto person)
        {
            ValidatePerson(person);
            await _repository.AddPersonAsync(person);
        }

        public Task EditPersonAsync(PersonDto person)
        {
            ValidatePerson(person);
            return _repository.EditPersonAsync(person);
        }
    }
}
