using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Responses;
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
        public static OwnerTenantDto ToDto(this EditOwnerTenantRequest request)
        {
            return new OwnerTenantDto
            {
                OwnerTenantId = request.OwnerTenantId ,
                OccupantCount = request.OccupantCount,
                IsOwner = request.IsOwner,
                From = request.From,
                To = request.To,
            };
        }

        public static OwnerTenantRespone ToModel(this OwnerTenantDto owner)
        {
            
            return new OwnerTenantRespone
            {
                OccupantCount = owner.OccupantCount,
                IsOwner = owner.IsOwner , 
                From = owner.From , 
                To = owner.To , 
                OwnerTenantId = owner.OwnerTenantId
            };
        }

        public static IEnumerable<OwnerTenantRespone> Project(this IEnumerable<OwnerTenantDto> ownertenants)
            => ownertenants.Select(o => o.ToModel());
    }
}
