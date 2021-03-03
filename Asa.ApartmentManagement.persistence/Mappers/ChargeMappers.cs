using Asa.ApartmentManagement.Core.ChargeCalculation;
using Asa.ApartmentManagement.Core.ChargeCalculation.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Asa.ApartmentManagement.Persistence.Mappers
{
    public static class ChargeMappers
    {
        public static ChargeDto ToDto(this Charge charge) 
            => new ChargeDto
            {
                CalculateDateTime = charge.CalculateDateTime,
                From = charge.From,
                To = charge.To
            };

        public static IEnumerable<ChargeDto> Project(this IEnumerable<Charge> charges) => charges.Select(ToDto);
    }
}
