using System;
using System.Globalization;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using MCPWebControllerApi.Models;
using Microsoft.Net.Http.Headers;

namespace MCPWebControllerApi.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Beverage> Beverages => Set<Beverage>();

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Beverage>().HasData(GetBeverages());
    }

    private static IEnumerable<Beverage> GetBeverages()
    {
        string[] p = { Directory.GetCurrentDirectory(), "wwwroot", "beverages.csv" };
        var csvPath = Path.Combine(p);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Encoding = Encoding.UTF8,
            PrepareHeaderForMatch = args => args.Header.ToLower()
        };

        var data = new List<Beverage>().AsEnumerable();
        using (var reader = new StreamReader(csvPath))
        {
            using (var csvReader = new CsvReader(reader, config))
            {
                data = csvReader.GetRecords<Beverage>().ToList();
            }
        }

        return data;
    }
}
