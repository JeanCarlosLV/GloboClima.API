namespace GloboClima.API.Models;

using System.Text.Json.Serialization;

public class Country
{
    [JsonPropertyName("name")]
    public CountryName? Name { get; set; }

    [JsonPropertyName("population")]
    public long Population { get; set; }

    [JsonPropertyName("currencies")]
    public Dictionary<string, Currency>? Currencies { get; set; }

    [JsonPropertyName("languages")]
    public Dictionary<string, string>? Languages { get; set; }

    [JsonPropertyName("capital")]
    public List<string>? Capitals { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("subregion")]
    public string? Subregion { get; set; }

    public class CountryName
    {
        [JsonPropertyName("common")]
        public string? Common { get; set; }

        [JsonPropertyName("official")]
        public string? Official { get; set; }
    }

    public class Currency
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("symbol")]
        public string? Symbol { get; set; }
    }
}
