using GeoCodingApp.Services;
using GeoCodingApp.Utilities;
using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Enter location:");
        string location = Console.ReadLine();

        if (!InputValidator.IsValidLocation(location))
        {
            Console.WriteLine("Invalid location input.");
            return;
        }

        var service = new GeocodingService();

        try
        {
            var results = await service.GetCoordinatesAsync(location);

            if (results.Count == 0)
            {
                Console.WriteLine("No results found.");
                return;
            }

            Console.WriteLine("\nResults:");

            foreach (var r in results)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine($"Address   : {r.display_name}");
                Console.WriteLine($"Latitude  : {r.lat}");
                Console.WriteLine($"Longitude : {r.lon}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}