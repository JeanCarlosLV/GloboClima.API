using GloboClima.API.Models;
using GloboClima.API.Services.Interfaces;
using System.Text.Json;

namespace GloboClima.API.Services;

public class WeatherService : IWeatherService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public WeatherService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Weather> GetWeatherAsync(string city)
    {
        try
        {
            var apiKey = _configuration["OpenWeatherMap:ApiKey"];
            if (string.IsNullOrEmpty(apiKey))
                throw new Exception("Chave da API não configurada");

            var url = $"/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=pt_br";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new HttpRequestException(
                    $"Erro na API: {response.StatusCode}. Detalhes: {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Weather>(json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"ERRO: {ex.Message}");
            throw new Exception($"Falha ao consultar clima para {city}. Verifique o nome da cidade.", ex);
        }
    }
}