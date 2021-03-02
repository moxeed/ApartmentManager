﻿using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManagement.Persistence.Mappers
{
    public static class PersonMappers
    {

        public static Person ToEntry(this PersonDto person)
        {
            return new Person
            {
                Name = person.Name,
                PersonId = person.PersonId,
                LastName = person.LastName,
                PhoneNumber = person.PhoneNumber
            };
        }

        public static OwnerTenant ToEntry(this OwnerTenantDto ownertenantDto)
        {
            return new OwnerTenant
            {
                OccupantCount = ownertenantDto.OccupantCount,
                IsOwner = ownertenantDto.IsOwner,
                From = ownertenantDto.From, 
                To = ownertenantDto.To, 
                PersonId = ownertenantDto.PersonId , 
                ApartmentId = ownertenantDto.ApartmentId ,
            };
        }
        public static OwnerTenantDto ToDto(this OwnerTenant ownertenant)
        {
            return new OwnerTenantDto
            {
                OccupantCount = ownertenant.OccupantCount,
                OwnerTenantId = ownertenant.OwnerTenantId,
                IsOwner = ownertenant.IsOwner,
                From = ownertenant.From,
                To = ownertenant.To,
                PersonId = ownertenant.PersonId,
                ApartmentId = ownertenant.ApartmentId,
            };
        }
        public static Task<IEnumerable<OwnerTenantDto>> OProject(this IEnumerable<OwnerTenant> ownertenant)
        => (Task<IEnumerable<OwnerTenantDto>>)ownertenant.Select(ToDto);


    }
}
