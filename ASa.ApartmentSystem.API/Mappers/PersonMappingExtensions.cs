using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class PersonMappingExtensions
    {
        public static PersonDto ToDto(this AddPersonRequests personRequest, int id = 0)
        {
            return new PersonDto
            {
                PersonId = id,
                Name = personRequest.Name ?? throw new NullReferenceException($"{nameof(personRequest.Name)} Was Nulll"),
                LastName = personRequest.LastName ?? throw new NullReferenceException($"{nameof(personRequest.LastName)} Was Nulll"),
                PhoneNumber = personRequest.PhoneNumber ?? throw new NullReferenceException($"{nameof(personRequest.PhoneNumber)} Was Nulll"),
            };
        }

        public static PersonResponse ToModel(this PersonDto person)
        {
            return new PersonResponse
            {
                PersonId = person.PersonId , 
                PhoneNumber = person.PhoneNumber , 
                LastName = person.LastName  ,
                Name = person.Name
            };
        }


        public static IEnumerable<PersonResponse> Project(this IEnumerable<PersonDto> persons)
             => persons.Select(p => p.ToModel());


    }
}
