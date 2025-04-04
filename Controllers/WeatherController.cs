using GloboClima.API.Models;
using GloboClima.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GloboClima.API.Controllers;

[ApiController]
[Route("api/weather")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet("{city}")]
    public async Task<ActionResult<Weather>> GetWeather(string city)
    {
        var weather = await _weatherService.GetWeatherAsync(city);
        return Ok(weather); // Retorna o DTO diretamente (serializado como JSON)
    }
}
