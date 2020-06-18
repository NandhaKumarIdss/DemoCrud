using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoData.Mapping
{
    class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("CityInfo")
                  .HasOne<State>(n => n.State)
                  .WithMany(o=> o.Cities)
                  .HasForeignKey(c => c.StateId)
                  .IsRequired();
            builder.Property(p=>p.CityName)
                .HasColumnName("CityName")
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(u => u.CityCode)
                   .HasColumnName("CityCode")
                   .HasColumnType("varchar(100)")
                   .IsRequired();

        }
    }
}
