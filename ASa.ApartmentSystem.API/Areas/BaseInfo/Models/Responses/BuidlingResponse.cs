namespace Asa.ApartmentSystem.API.Areas.BaseInfo.Models
{
    public class BuidlingResponse
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }
        public int ApartmentCount { get; set; }
        public decimal Budget { get; set; }
        public int OcuupantCount { get; set; }
    }
}