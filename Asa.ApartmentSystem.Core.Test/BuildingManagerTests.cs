using ASa.ApartmentManagement.Core.BaseInfo.DTOs;
using ASa.ApartmentManagement.Core.BaseInfo.Managers;
using NUnit.Framework;
using System.Threading.Tasks;
using Moq;
using ASa.ApartmentManagement.Core.BaseInfo.DataGateways;
using ASa.ApartmentManagement.Core;

namespace Asa.ApartmentSystem.Core.Test
{
    public class BuildingManagerTests
    {
        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public void RUN_Just_For_Test()
        {
            //A
            BuildingManager buildingManager = new BuildingManager(new MyFakes.TableGatewyFactory());
            int a = 10;
            int b = 15;
            //A

            var result = buildingManager.JustForTest(a, b);
            //A
            Assert.AreEqual(a + b, result);
        }

        [Test]
        public async Task Building_Name_Cannot_Be_Null_Or_Empty()
        {
            //A => Arange

            BuildingManager buildingManager = new BuildingManager(new MyFakes.TableGatewyFactory());
            BuildingDTO building = new BuildingDTO { Id = 0, Name = string.Empty, NumberOfUnits = 10 };
            //A => Act
            //A => Assert
            Assert.CatchAsync(() => buildingManager.AddBuilding(building));

            //AsyncTestDelegate asyncTestDelegate = DoMyAcgtion;
            //Assert.CatchAsync(asyncTestDelegate);
        }

        [Test]
        public async Task Building_Added_Successfuly()
        {
            //A => Arange

            BuildingManager buildingManager = new BuildingManager(new MyFakes.TableGatewyFactory());
            BuildingDTO building = new BuildingDTO { Id = 0, Name = "My Building", NumberOfUnits = 10 };
            //A => Act
             await buildingManager.AddBuilding(building);
            //A => Assert
            Assert.AreEqual(1, building.Id);
        }

        [Test]
        public async Task Building_Added_Successfuly_With_Moq()
        {
            //A => Arange

            Mock<ITableGatwayFactory> mock_ITableGatwayFactory = new Mock<ITableGatwayFactory>();

            Mock<IBuildingTableGateway> mock_IBuildingTableGateway = new Mock<IBuildingTableGateway>();
            int myId = 10;
            mock_IBuildingTableGateway.Setup(x => x.InsertBuildingAsync(It.IsAny<BuildingDTO>())).ReturnsAsync(myId);
            mock_ITableGatwayFactory.Setup(x => x.CreateBuildingTableGateway()).Returns(mock_IBuildingTableGateway.Object);

            BuildingManager buildingManager = new BuildingManager(mock_ITableGatwayFactory.Object);
            BuildingDTO building = new BuildingDTO { Id = 0, Name = "My Building", NumberOfUnits = 10 };

            //A => Act
            await buildingManager.AddBuilding(building);

            //A => Assert
            Assert.AreEqual(myId, building.Id);
        }
        //FAKE Mock Stub Dummy
        //Autofac

        //private async Task DoMyAcgtion()
        //{
        //    BuildingManager buildingManager = new BuildingManager();
        //    BuildingDTO building = new BuildingDTO { Id = 0, Name = string.Empty, NumberOfUnits = 10 };
        //    await buildingManager.AddBuilding(building);
        //}

        public async Task Test()
        {
            SampleInternal sampleInternal = new ASa.ApartmentManagement.Core.SampleInternal();
        }
    }
}