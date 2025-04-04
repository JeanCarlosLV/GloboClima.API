using GloboClima.API.Services.Interfaces;

namespace GloboClima.API.Services;

using GloboClima.API.Models;
using System.Net;
using System.Text.Json;

public class CountryService : ICountryService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<CountryService> _logger;

    public CountryService(HttpClient httpClient, ILogger<CountryService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<Country>> GetCountryInfoAsync(string name)
    {
        try
        {
            var response = await _httpClient.GetAsync($"name/{name}?fields=name,population,currencies,languages,capital,region,subregion");

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                _logger.LogWarning($"País '{name}' não encontrado");
                return new List<Country>();
            }

            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            return JsonSerializer.Deserialize<List<Country>>(content, options) ?? new List<Country>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, $"Erro ao consultar país: {name}");
            throw new Exception($"Erro ao consultar informações do país: {ex.Message}");
        }
    }
}