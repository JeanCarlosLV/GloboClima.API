using GloboClima.API.Models;
using GloboClima.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace GloboClima.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoriteRepository _repository;

    public FavoritesController(FavoriteRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> AddFavorite([FromBody] FavoriteRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Type) || string.IsNullOrEmpty(request.Name))
        {
            return BadRequest("Type e Name são obrigatórios");
        }

        var favorite = new Favorite
        {
            UserId = "default-user",
            Type = request.Type.ToLower(),
            Name = request.Name
        };

        await _repository.SaveFavorite(favorite);
        return CreatedAtAction(nameof(GetFavorites), favorite);
    }

    [HttpGet]
    public async Task<IActionResult> GetFavorites()
    {
        try
        {
            var favorites = await _repository.GetUserFavorites("default-user");
            return Ok(favorites);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao buscar favoritos: {ex.Message}");
        }
    }

    [HttpDelete("{favoriteId}")]
    public async Task<IActionResult> DeleteFavorite(string favoriteId)
    {
        try
        {
            if (string.IsNullOrEmpty(favoriteId))
            {
                return BadRequest("FavoriteId é obrigatório");
            }

            await _repository.DeleteFavorite("default-user", favoriteId);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao excluir favorito: {ex.Message}");
        }
    }
}

public class FavoriteRequest
{
    public string Type { get; set; }
    public string Name { get; set; }
}