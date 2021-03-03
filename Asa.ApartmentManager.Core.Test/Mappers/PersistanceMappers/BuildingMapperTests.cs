using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Persistence.Mappers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManager.Core.Test.Mappers.PersistanceMappers
{
    public class BuildingMapperTests
    {

        [Test]
        public void Building_Map_to_BuildingDto()
        {

            BuildingInfo otdto = new BuildingInfo
            {
                BuildingId = 1,
                BuildingName ="gholam",
                ApartmentCount= 4
            };
            BuildingDto ow = otdto.ToDto();

            bool check = false;
            if (ow.BuildingId == otdto.BuildingId&& ow.ApartmentCount== otdto.ApartmentCount&& 
                   ow.Name == otdto.BuildingName)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }

        [Test]
        public void BuildingDto_Map_To_Entry()
        {

            BuildingDto otdto = new BuildingDto
            {
                BuildingId = 1,
                Name = "gholam",
                ApartmentCount = 4
            };
            BuildingInfo ow = otdto.ToEntry();

            bool check = false;
            if (ow.BuildingId == otdto.BuildingId && ow.ApartmentCount == otdto.ApartmentCount &&
                   otdto.Name == ow.BuildingName)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }
        [Test]
        public void Apartment_Map_To_Entry()
        {

            ApartmentDto otdto = new ApartmentDto
            {
                BuildingId = 1,
                Area = 29 , 
                ApartmentId = 4 , 
                Number = 34
                
            };
            ApartmentInfo ow = otdto.ToEntry();

            bool check = false;
            if (otdto.Number == ow.Number && otdto.BuildingId == ow.BuildingId &&
                otdto.ApartmentId == ow.ApartmentId && ow.Area == otdto.Area)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }
        [Test]
        public void Apartment_Map_To_ApartmentDto()
        {

            ApartmentInfo otdto = new ApartmentInfo
            {
                BuildingId = 1,
                Area = 29,
                ApartmentId = 4,
                Number = 34,
                
            };
            var ow = otdto;
            bool check = true;
            if (otdto.Number == ow.Number && otdto.BuildingId == ow.BuildingId &&
                otdto.ApartmentId == ow.ApartmentId && ow.Area == otdto.Area)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }
    }
}
