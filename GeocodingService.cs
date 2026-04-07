using GeoCodingApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeoCodingApp.Services
{
    public class GeocodingService
    {
        private readonly HttpClient _httpClient;

        public GeocodingService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GeoCodingApp");
        }

        public async Task<List<NominatimResult>> GetCoordinatesAsync(string location)
        {
            string url =
                $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(location)}&format=json";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch data from API");

            var json = await response.Content.ReadAsStringAsync();

            var results = JsonSerializer.Deserialize<List<NominatimResult>>(json);

            return results ?? new List<NominatimResult>();
        }
    }
}