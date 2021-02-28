using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class PersonMappingExtensions
    {
        public static PersonDto ToDto(this PersonRequest personRequest, int id = 0)
        {
            return new PersonDto
            {
                PersonId = id,
                Name = personRequest.Name,
                LastName = personRequest.LastName,
                PhoneNumber = personRequest.PhoneNumber
            };
        }
    }
}
