using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models;
using Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asa.ApartmentSystem.API.Mappers
{
    public static class AparrtmentMappingExtensions
    {
        public static ApartmentResponse ToModel(this ApartmentDto apartment) 
        {
            return new ApartmentResponse
            {
                ApartmentId = apartment.ApartmentId,
                Area = apartment.Area,
                CurrentOccupant = "NoOne",
                Number = apartment.Number
            };
        }
        
        public static IEnumerable<ApartmentResponse> Project(this IEnumerable<ApartmentDto> apartments) 
            => apartments.Select(b => b.ToModel());

        public static ApartmentDto ToDto(this AddApartmentRequest addApartmentRequest)
        {
            return new ApartmentDto
            {
                BuildingId = addApartmentRequest.BuildingID ,
                Number = addApartmentRequest.Number 
                ?? throw new NullReferenceException($"{nameof(addApartmentRequest.Number)} Was Nulll"),
                Area = addApartmentRequest.Area
                ?? throw new NullReferenceException($"{nameof(addApartmentRequest.Area)} Was Nulll")
            };
        }
    }
}
