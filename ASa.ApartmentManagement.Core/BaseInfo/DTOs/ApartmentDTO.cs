namespace Asa.ApartmentManagement.Core.BaseInfo.DTOs
{
    public class ApartmentDto
    {
        public int ApartmentId { get; set; }
        public int Number { get; set; }
        public int BuidlingId { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }
    }
}
