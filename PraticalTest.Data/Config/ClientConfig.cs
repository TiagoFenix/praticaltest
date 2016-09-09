using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace PraticalTest.Data
{
    class ClientConfig: EntityTypeConfiguration<ClientDataModel>
    {
        public ClientConfig()
        {
            ToTable("Client");

            HasKey(c => c.ClientId);

            Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            Property(c => c.Phone)
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(200);

            Property(c => c.Gender)                
                .HasColumnType("nvarchar")
                .HasMaxLength(1);

            Property(c => c.LastPurchase)                
                .HasColumnType("datetime");

            HasRequired(c => c.Seller)
                .WithMany(t => t.Clients)
                .HasForeignKey(m => m.SellerId);

            HasOptional(c => c.Region)
                .WithMany(t => t.Clients)
                .HasForeignKey(m => m.RegionId);

            HasOptional(c => c.Classification)
                .WithMany(t => t.Clients)
                .HasForeignKey(m => m.ClassificationId);
        }
    }
}
