using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.ApartmentManagement.Persistence.Mappers
{
    public static class BuildingMappers
    {
        public static BuildingDto ToDto(this BuildingInfo building)
        {
            return new BuildingDto
            {
                BuildingId = building.BuildingId,
                Name = building.BuildingName,
                ApartmentCount = building.ApartmentCount
            };
        }

        public static IEnumerable<BuildingDto> Project(this IEnumerable<BuildingInfo> buildings) => buildings.Select(b => b.ToDto());

        public static BuildingInfo ToEntry(this BuildingDto building)
        {
            return new BuildingInfo
            {
                BuildingId = building.BuildingId,
                BuildingName= building.Name,
                ApartmentCount= building.ApartmentCount
            };
        }

        public static BuildingInfo ToEntry(this BuildingNameDto buildingName, BuildingInfo building)
        {
            building.BuildingName = buildingName.BuildingName;
            return building;
        }

        public static ApartmentDto ToDto(this ApartmentInfo apartment) 
        {
            return new ApartmentDto
            {
                ApartmentId = apartment.ApartmentId,
                Area = apartment.Area,
                BuildingId = apartment.BuildingId,
                Number = apartment.Number,
                OccupantCount = apartment.OwnerTenants
                .Where(c => c.To == null)
                .Sum(c => c.OccupantCount)
            };
        }

        public static ApartmentInfo ToEntry(this ApartmentDto apartment)
        {
            return new ApartmentInfo
            {
                ApartmentId = apartment.ApartmentId,
                Area = apartment.Area,
                BuildingId = apartment.BuildingId,
                Number = apartment.Number
            };
        }

        public static IEnumerable<ApartmentDto> Project(this IEnumerable<ApartmentInfo> apartments) => apartments.Select(a => a.ToDto());

        
    }
}
