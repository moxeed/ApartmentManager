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
        FakeBuildingRepository _repository;
        BuildingManager buildingManager;
        [SetUp]
        public void Setup()
        {
            _repository = new FakeBuildingRepository();
            buildingManager = new BuildingManager(_repository); 
        }

        [Test]
        public void Building_Name_Cannot_Be_Null_Or_Empty()
        {
            BuildingDto building = new BuildingDto { BuildingId = 0, Name = string.Empty, NumberOfUnits = 10 };
            Assert.CatchAsync(() => buildingManager.AddBuildingAsync(building));
        }

        [Test]
        public async Task Building_Added_Successfuly()
        {
            BuildingDto building = new BuildingDto { BuildingId = 1, Name = "MyBuilding", NumberOfUnits = 10 };
            await buildingManager.AddBuildingAsync(building);
            Assert.AreEqual(1, building.BuildingId);
        }

        [Test]
        public async Task Buillding_Edit_Successfuly()
        {
            BuildingNameDto buildingname = new BuildingNameDto { BuildingId = 1, BuildingName = "Salam" };
            BuildingDto building = new BuildingDto { BuildingId = 1, Name = "Khodafes", NumberOfUnits = 10 };
            await buildingManager.AddBuildingAsync(building);
            await buildingManager.EditBuldingNameAsync(buildingname);
            var editedbuilding  = await _repository.GetBuildingAsync(building.BuildingId);
            Assert.AreEqual("Salam", editedbuilding.Name);
        }
        
    }
}