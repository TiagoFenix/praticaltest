using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class ClassificationConfig : EntityTypeConfiguration<ClassificationDataModel>
    {
        public ClassificationConfig()
        {
            ToTable("Classification");

            HasKey(c => c.ClassificationId);

            Property(c => c.ClassificationName)                
                .HasColumnType("varchar")
                .HasMaxLength(100);
        }
    }
}
