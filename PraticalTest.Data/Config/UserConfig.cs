using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    public class UserConfig : EntityTypeConfiguration<UserDataModel>
    {
        public UserConfig()
        {
            ToTable("User");

            HasKey(c => c.UserId);

            Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar");

            Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar");

            Property(c => c.Password)
                .IsRequired()
                .HasColumnType("varchar");
        }
    }
}
