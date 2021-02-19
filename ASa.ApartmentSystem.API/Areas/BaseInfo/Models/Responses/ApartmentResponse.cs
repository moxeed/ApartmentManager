namespace Asa.ApartmentSystem.API.Mappers
{
    public class ApartmentResponse
    {
        public int ApartmentId {get;set;}
        public int Number {get;set;}
        public decimal Area {get;set;}
        public string CurrentOccupant {get;set;}
    }
}