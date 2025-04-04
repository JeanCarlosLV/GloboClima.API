using GloboClima.API.Models;

namespace GloboClima.API.Services.Interfaces;

public interface ICountryService
{
    Task<List<Country>> GetCountryInfoAsync(string name);
}