using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace GeoData.Mapping
{
    public class CountryMapping : IEntityTypeConfiguration<Country>
    {
        
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.ToTable("Countries_Info");
            builder.Property(p => p.CountryId)
                .HasColumnName("CountryId")
                .UseIdentityColumn(1, 1)
                .IsRequired();
            builder.Property(c => c.CountryName)
                .HasColumnName("CountryName")
                .HasColumnType("varchar(200)")
                .IsRequired();
            builder.Property(n => n.CountryCode)
                .HasColumnName("CountryCode")
                .HasColumnType("nvarchar(200)")
                .IsRequired();
        }
    }
}
