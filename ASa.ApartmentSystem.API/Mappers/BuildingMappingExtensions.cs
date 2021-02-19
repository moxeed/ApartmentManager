using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class BuildingMappingExtensions
    {
        public static BuidlingResponse ToModel(this BuildingDto building) 
        {
            return new BuidlingResponse
            {
                BuildingId = building.Id,
                ApartmentCount = building.NumberOfUnits,
                OcuupantCount = 0,
                Budget = 0
            };
        }
        
        public static IEnumerable<BuidlingResponse> Project(this IEnumerable<BuildingDto> buildings) 
            => buildings.Select(b => b.ToModel());

        public static BuildingDto ToDto(this AddBuildingRequest addBuildingRequest)
        {
            return new BuildingDto
            {
                NumberOfUnits = addBuildingRequest.AparatmentCount 
                ?? throw new NullReferenceException($"{nameof(addBuildingRequest.AparatmentCount)} Was Null"),
                Name = addBuildingRequest.Name
            };
        }

        public static BuildingNameDto ToDto(this RenameBuildingRequest renameBuildingRequest)
        {
            return new BuildingNameDto
            {
                BuildingId = renameBuildingRequest.BuildingId 
                ?? throw new NullReferenceException($"{nameof(renameBuildingRequest.BuildingId)} Was Null"),
                BuildingName = renameBuildingRequest.Name
            };
        }
    }
}
