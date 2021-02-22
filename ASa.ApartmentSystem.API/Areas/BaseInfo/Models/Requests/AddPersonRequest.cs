using System.ComponentModel.DataAnnotations;

namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models.Requests
{
    public class PersonRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
