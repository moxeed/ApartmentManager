using Asa.ApartmentManagement.Core.BaseInfo.Domain;
using Asa.ApartmentManagement.Core.BaseInfo.DTOs;
using NUnit.Framework;
using Asa.ApartmentManagement.Persistence.Mappers;
using System;

namespace Asa.ApartmentManager.Core.Test.Mappers.PersistanceMappers
{
    public class PersonMapperTests
    {
      
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Person_Map_ToDto() 
        {
            Person person = new Person { Name = "alie", LastName = "ali", PersonId = 12, PhoneNumber = "09129875432" };
            PersonDto pdto = person.ToDto();
            bool check = false;
            if(pdto.Name == person.Name && pdto.LastName == person.LastName && 
                pdto.PersonId == person.PersonId && pdto.PhoneNumber == person.PhoneNumber)
            {
                check = true; 
            }
            Assert.IsTrue(check);
        }

        [Test]
        public void PersonDto_Map_To_Entry()
        {
            PersonDto pdto = new PersonDto { PersonId = 1, Name = "karim", LastName = "karimi", PhoneNumber = "09128829876" };
            Person p = pdto.ToEntry();
            bool check = false;
            if(pdto.PhoneNumber == p.PhoneNumber && pdto.PersonId == p.PersonId && 
                pdto.LastName == p.LastName && pdto.Name == p.Name)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }


        [Test]
        public void OwnertenatDto_Map_To_Entry()
        {
 
            DateTime now = DateTime.Now;
            OwnerTenantDto otdto = new OwnerTenantDto { PersonId = 1, From = now  ,  IsOwner = false , OccupantCount=4
                                                        ,OwnerTenantId=7 , ApartmentId = 4 };
            OwnerTenant ow = otdto.ToEntry();

            bool check = false;
            if (ow.IsOwner == otdto.IsOwner && ow.From == otdto.From && ow.ApartmentId == otdto.ApartmentId &&
                ow.OccupantCount == otdto.OccupantCount && ow.PersonId == otdto.PersonId)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }

        [Test]
        public void OwnerTenant_Map_To_OwnerTenantDto()
        {
            DateTime now = DateTime.Now;
            OwnerTenant otdto = new OwnerTenant
            {
                PersonId = 1,
                From = now,
                IsOwner = false,
                OccupantCount = 4
                                                        ,
                OwnerTenantId = 7,
                ApartmentId = 4
            };
            OwnerTenantDto ow = otdto.ToDto();

            bool check = false;
            if (ow.IsOwner == otdto.IsOwner && ow.From == otdto.From && ow.ApartmentId == otdto.ApartmentId &&
                ow.OccupantCount == otdto.OccupantCount && ow.PersonId == otdto.PersonId)
            {
                check = true;
            }
            Assert.IsTrue(check);
        }
    }
}
