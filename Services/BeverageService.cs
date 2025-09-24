using System;
using System.Net.Http.Json;
using System.Text.Json;
using System.Globalization;
using CsvHelper;

using MCPWebControllerApi.Models;

namespace MCPWebControllerApi.Services;

public class BeverageService
{
    private readonly string SUGAR = "sugar";
    readonly HttpClient _httpClient = new();
    private List<Beverage>? _bevCache = null;
    private DateTime _cacheTime;
    private readonly TimeSpan _cacheDuration = TimeSpan.FromMinutes(10);

    private async Task<List<Beverage>> FetchBeverageFromApi()
    {
        try
        {
            // This is not JSON its CSV so I grabbed a package to easily parse CSV data
            // https://www.nuget.org/packages/CsvHelper/
            var res = await _httpClient.GetAsync("https://gist.githubusercontent.com/medhatelmasry/be88d4721ee8e2aacabc946a54d88d8e/raw/e7e338fa83212c08a7a04fafaa3694a19a0dbe66/beverages.csv");
            if (res.IsSuccessStatusCode)
            {
                var stream = await res.Content.ReadAsStreamAsync();
                // resource
                using var reader = new StreamReader(stream);
                // resource
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<Beverage>().ToList();
                return records ?? [];
            }
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync($"Error fetching beverages from API: {ex.Message}");
        }
        return [];
    }

    public async Task<List<Beverage>> GetBeverages()
    {
        if (_bevCache == null || DateTime.UtcNow - _cacheTime > _cacheDuration)
        {
            _bevCache = await FetchBeverageFromApi();
            _cacheTime = DateTime.UtcNow;
        }
        return _bevCache;
    }

    public async Task<Beverage?> GetBeverageByName(string name)
    {
        var bevs = await GetBeverages();

        foreach (var b in bevs.Where(b => b.Name?.Contains(name) == true))
        {
            Console.WriteLine($"Found partial match for bev name {name}, {b.Name}");
        }

        var bev = bevs.FirstOrDefault(b =>
        {
            var nameMatch = string.Equals(b.Name, name);
            return nameMatch;
        });

        return bev;
    }

    public async Task<Beverage?> GetBeverageById(int id)
    {
        var bevs = await GetBeverages();
        var bev = bevs.FirstOrDefault(b => b.BeverageId == id);

        return bev;
    }

    public async Task<List<Beverage>?> GetBeveragesByType(string type)
    {
        var bevs = await GetBeverages();
        var bevsT = bevs
            .Where(b => b.Type?.Equals(type, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();

        return bevsT;
    }

    public async Task<List<Beverage>?> GetBeveragesByMainIngredient(string mainIngredient)
    {
        var bevs = await GetBeverages();
        var bevsI = bevs
            .Where(b => b.MainIngredient?.Equals(mainIngredient, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();

        return bevsI;
    }

    public async Task<List<Beverage>?> GetBeveragesByOrigin(string origin)
    {
        var bevs = await GetBeverages();
        var bevsO = bevs
            .Where(b => b.Origin?.Equals(origin, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();

        return bevsO;
    }

    public async Task<List<Beverage>?> GetBeveragesWithSugar()
    {
        var bevs = await GetBeverages();
        var bevsWS = bevs
            .Where(b => b.MainIngredient?.Contains(SUGAR, StringComparison.OrdinalIgnoreCase) == true)
            .ToList();

        return bevsWS;
    }

    public async Task<Beverage?> GetBeverageWithMostCalories()
    {
        var bevs = await GetBeverages();
        var bevMC = bevs.OrderByDescending(b => b.CaloriesPerServing).FirstOrDefault();

        return bevMC;
    }

    public async Task<string> GetBeveragesJson()
    {
        var bevs = await GetBeverages();
        return JsonSerializer.Serialize(bevs);
    }
}
