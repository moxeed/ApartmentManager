using NUnit.Framework;
using System.Threading.Tasks;
using Asa.ApartmentManagement.Core.Interfaces.Repositories;
using Asa.ApartmentManagement.Core.BaseInfo.Managers;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Persistence.FakeRepositories;
using System;


namespace Asa.ApartmentSystem.Core.Test
{
    public class BuildingManagerTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Building_Name_Cannot_Be_Null_Or_Empty()
        {
            FakeBuildingRepository _repository = new FakeBuildingRepository();
            BuildingManager buildingManager = new BuildingManager(_repository);
            BuildingDto building = new BuildingDto { BuildingId = 0, Name = string.Empty, NumberOfUnits = 10 };
            Assert.CatchAsync(() => buildingManager.AddBuildingAsync(building));
        }

        [Test]
        public async Task Building_Added_Successfuly()
        {
            FakeBuildingRepository _repository = new FakeBuildingRepository();
            BuildingManager buildingManager = new BuildingManager(_repository);
            BuildingDto building = new BuildingDto { BuildingId= 1, Name = "MyBuilding", NumberOfUnits = 10 };
            await buildingManager.AddBuildingAsync(building);
            Console.WriteLine(building.BuildingId);
            Assert.AreEqual(1, building.BuildingId);
        }


        
    }
}