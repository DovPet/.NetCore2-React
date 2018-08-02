using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using amidus.Persistence;
public class AmidusDbContextFactory : IDesignTimeDbContextFactory<AmidusDbContext>
{
  //////// 
     public AmidusDbContext CreateDbContext(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
        var builder = new DbContextOptionsBuilder<AmidusDbContext>();
        var connectionString = configuration.GetConnectionString("Default");
        builder.UseSqlServer(connectionString);
        return new AmidusDbContext(builder.Options);
    }

}