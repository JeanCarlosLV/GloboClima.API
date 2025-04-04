namespace GloboClima.API.Controllers;

using GloboClima.API.Models;
using GloboClima.API.Services.Interfaces;

// Controllers/CountriesController.cs
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class CountriesController : ControllerBase
{
    private readonly ICountryService _countryService;
    private readonly ILogger<CountriesController> _logger;

    public CountriesController(ICountryService countryService, ILogger<CountriesController> logger)
    {
        _countryService = countryService;
        _logger = logger;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetCountry(string name)
    {
        try
        {
            var countries = await _countryService.GetCountryInfoAsync(name);

            if (countries == null || !countries.Any())
            {
                return Ok(new List<Country>()); // Retorna array vazio
            }

            return Ok(countries);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Error = ex.Message });
        }
    }
}