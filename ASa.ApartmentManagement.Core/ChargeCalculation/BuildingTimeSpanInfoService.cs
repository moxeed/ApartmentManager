using System;
using System.Collections.Generic;

namespace Asa.ApartmentManagement.Core.ChargeCalculation
{
    public class BuildingTimeSpanInfoService
    {
        public BuildingTimeSpanInfoService(ChargeBuilding building, DateTime from, DateTime to)
        {
            Building = building;
            From = from;
            To = to;
        }
        public decimal Area => Building.Area;
        public ChargeBuilding Building { get; }
        public DateTime From { get; }
        public DateTime To { get; }

        internal decimal GetApartmentArea(int apartmentId)
            => Building.GetApartmentArea(apartmentId);

        internal IEnumerable<(int PayerId, int DaysLived, int OccupantCount)> GetPayerResidenceInfos()
            => Building.GetPayerResidenceInfos(From, To);

        internal IEnumerable<(int PayerId, int DaysLived, int OccupantCount)> GetApartmentPayerResidenceInfos(int apartmentId)
            => Building.GetApartmentPayerResidenceInfos(From, To, apartmentId);
    }
}
