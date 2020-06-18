using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace GeoData
{
    public class GeoDBContext:DbContext
    {
        public GeoDBContext(DbContextOptions<GeoDBContext> options) : base(options)
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<City> City { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GeoDBContext).Assembly);
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<GeoDBContext>
    {
        public GeoDBContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<GeoDBContext>();
            var connectionString = configuration.GetConnectionString("connectionstring");
            builder.UseSqlServer(connectionString);
            return new GeoDBContext(builder.Options);
            //var builder = new DbContextOptionsBuilder<GeoDBContext>();
            //var connectionString = configuration.GetConnectionString("connectionstring");
            //builder.UseNpgsql(connectionString);
            //return new GeoDBContext(builder.Options);
        }
    }
}
