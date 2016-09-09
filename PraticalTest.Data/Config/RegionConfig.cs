using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    class RegionConfig: EntityTypeConfiguration<RegionDataModel>
    {
        public RegionConfig()
        {
            ToTable("Region");

            HasKey(c => c.RegionId);

            Property(c => c.RegionName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            HasRequired(c => c.City)
                .WithMany(t => t.Regions)
                .HasForeignKey(m => m.CityId);
        }
    }
}
