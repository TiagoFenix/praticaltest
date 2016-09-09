using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class CityConfig: EntityTypeConfiguration<CityDataModel>
    {
        public CityConfig()
        {
            ToTable("City");

            HasKey(c => c.CityId);

            Property(c => c.CityName)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
