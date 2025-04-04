using System.Text.Json.Serialization;

namespace GloboClima.API.Models;

// Models/WeatherResponse.cs
public class Weather
{
    [JsonPropertyName("name")]
    public string? CityName { get; set; }

    [JsonPropertyName("main")]
    public MainData? Main { get; set; }

    [JsonPropertyName("weather")]
    public List<WeatherDescription>? WeatherDesc { get; set; }
}

public class MainData
{
    [JsonPropertyName("temp")]
    public float Temperature { get; set; }

    [JsonPropertyName("humidity")]
    public int Humidity { get; set; }
}

public class WeatherDescription
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
