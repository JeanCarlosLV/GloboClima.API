namespace GloboClima.API.Models;

using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("GloboClimaFavorites")]
public class Favorite
{
    [DynamoDBHashKey]
    public string UserId { get; set; } = "default-user";

    [DynamoDBRangeKey]
    public string FavoriteId { get; set; } = Guid.NewGuid().ToString();

    [DynamoDBProperty]
    public string Type { get; set; }
    [DynamoDBProperty]
    public string Name { get; set; }

    [DynamoDBProperty(StoreAsEpoch = true)]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}