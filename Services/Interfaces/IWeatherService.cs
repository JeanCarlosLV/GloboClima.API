using GloboClima.API.Models;

namespace GloboClima.API.Services.Interfaces;

public interface IWeatherService
{
    Task<Weather> GetWeatherAsync(string city);
}
