using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using Asa.ApartmentManagement.Core.BaseInfo.Managers;
using Asa.ApartmentManagement.Persistence.FakeRepositories;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Asa.ApartmentManager.Core.Test.BaseInfo
{
    public class PersonManagerTests
    {
        FakeBuildingRepository _buildingrepository;
        FakePersonRepository _personrepository;

        BuildingManager buildingManager;
        PersonManager personManager;
        [SetUp]
        public void Setup()
        {
            _buildingrepository = new FakeBuildingRepository();
            buildingManager = new BuildingManager(_buildingrepository);

            _personrepository = new FakePersonRepository();
            personManager = new PersonManager(_personrepository , buildingManager);
           
        }


        [Test]
        public async Task Person_Added_Successfuly()
        {
            PersonDto person = new PersonDto { PersonId = 1, Name = "kamal",  LastName="kamali" , PhoneNumber= "0982717672" };
            await personManager.AddPersonAsync(person);
            var addedperson = await _personrepository.GetPersonById(person.PersonId);
            Assert.AreEqual(1, addedperson.PersonId);
        }

        [Test]
        public void Person_Name_Cannot_Be_Null_Or_Empty()
        {
            PersonDto person = new PersonDto { PersonId = 0, Name = string.Empty,LastName="TestAgain", PhoneNumber = "0999282618" };
            Assert.CatchAsync(() => personManager.AddPersonAsync(person));
        }
        [Test]
        public void Person_LastName_Cannot_Be_Null_Or_Empty()
        {
            PersonDto person = new PersonDto { PersonId = 0, Name = "mamad", PhoneNumber = "0999282618" };
            Assert.CatchAsync(() => personManager.AddPersonAsync(person));
        }
        [Test]
        public async Task Person_Edit_Successfuly()
        {
            PersonDto editperson = new PersonDto { PersonId = 1, Name="salam" , LastName = "ha", PhoneNumber = "0999282618" };
            PersonDto person = new PersonDto { PersonId = 1, Name = "Khodafes", LastName="ha" , PhoneNumber= "0999282618" };
            await personManager.AddPersonAsync(person);
            await personManager.EditPersonAsync(editperson);
            var editedbuilding = await _personrepository.GetPersonById(person.PersonId);
            Assert.AreEqual("salam", editperson.Name);
        }




    }
}

