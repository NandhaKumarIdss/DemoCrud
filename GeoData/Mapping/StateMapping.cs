using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeoData.Mapping
{
    class StateMapping : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.ToTable("StateInfo")
                 .HasOne<Country>(s => s.Country)
                 .WithMany(g => g.States)
                 .HasForeignKey(c => c.CountryId)
                 .IsRequired();
            builder.Property(s => s.StateName)
                .HasColumnName("StateName")
                .HasColumnType("varchar(100)")
                .IsRequired(); 
            builder.Property(p => p.StateCode)
                   .HasColumnName("StateCode")
                   .HasColumnType("varchar(100)")
                   .IsRequired(); 
 




        }
    }
}
