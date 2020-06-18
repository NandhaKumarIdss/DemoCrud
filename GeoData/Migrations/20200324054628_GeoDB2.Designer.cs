﻿// <auto-generated />
using System;
using GeoData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GeoData.Migrations
{
    [DbContext(typeof(GeoDBContext))]
    [Migration("20200324054628_GeoDB2")]
    partial class GeoDB2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityCode")
                        .IsRequired()
                        .HasColumnName("CityCode")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnName("CityName")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.Property<int?>("StateId1")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("StateId");

                    b.HasIndex("StateId1")
                        .IsUnique()
                        .HasFilter("[StateId1] IS NOT NULL");

                    b.ToTable("CityInfo");
                });

            modelBuilder.Entity("Entities.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CountryId")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 0)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnName("CountryCode")
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnName("CountryName")
                        .HasColumnType("varchar(200)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries_Info");
                });

            modelBuilder.Entity("Entities.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("StateCode")
                        .IsRequired()
                        .HasColumnName("StateCode")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnName("StateName")
                        .HasColumnType("varchar(100)");

                    b.HasKey("StateId");

                    b.HasIndex("CountryId");

                    b.ToTable("StateInfo");
                });

            modelBuilder.Entity("Entities.City", b =>
                {
                    b.HasOne("Entities.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.State", null)
                        .WithOne("City")
                        .HasForeignKey("Entities.City", "StateId1");
                });

            modelBuilder.Entity("Entities.State", b =>
                {
                    b.HasOne("Entities.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}