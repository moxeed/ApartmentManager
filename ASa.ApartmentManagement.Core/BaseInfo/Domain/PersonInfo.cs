using Asa.ApartmentManagement.Core.Common;

namespace Asa.ApartmentManagement.Core.BaseInfo.Domain
{
    public class PersonInfo : IEntity
    {
        public int PersonId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
    }
}