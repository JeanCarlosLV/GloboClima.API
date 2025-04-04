using Amazon.DynamoDBv2.DataModel;
using GloboClima.API.Models;

namespace GloboClima.API.Services;

public class FavoriteRepository
{
    private readonly IDynamoDBContext _context;

    public FavoriteRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task SaveFavorite(Favorite favorite)
    {
        if (string.IsNullOrEmpty(favorite.Type) || string.IsNullOrEmpty(favorite.Name))
        {
            throw new ArgumentException("Type e Name são obrigatórios");
        }

        await _context.SaveAsync(favorite);
    }

    public async Task<List<Favorite>> GetUserFavorites(string userId)
    {
        return await _context.QueryAsync<Favorite>(userId)
                           .GetRemainingAsync();
    }

    public async Task DeleteFavorite(string userId, string favoriteId)
    {
        await _context.DeleteAsync<Favorite>(userId, favoriteId);
    }
}
