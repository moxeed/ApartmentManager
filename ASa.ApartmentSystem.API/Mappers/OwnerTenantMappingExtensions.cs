using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class OwnerTenantMappingExtensions
    {
        public static OwnerTenantDto ToDto(this AddOwnerTenantRequest request)
        {
            return new OwnerTenantDto
            {
                OccupantCount = request.OccupantCount,
                IsOwner = request.IsOwner,
                From = request.From ,
                To = request.To , 
                PersonId = request.PersonId, 
                ApartmentId = request.ApartmentId

            };
        }

    }
}
