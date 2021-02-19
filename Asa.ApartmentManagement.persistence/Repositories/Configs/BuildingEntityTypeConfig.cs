using Asa.ApartmentManagement.Core.ChargeCalculation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asa.ApartmentManagement.Persistence.Repositories.Configs
{
    public class BuildingEntityTypeConfig : IEntityTypeConfiguration<Building>
    {
            public void Configure(EntityTypeBuilder<Building> builder)
            {
                builder.HasKey(x => x.BuildingId);

            }
    }
}
