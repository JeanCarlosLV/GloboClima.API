// GloboClima.API/Models/User.cs
using Amazon.DynamoDBv2.DataModel;

[DynamoDBTable("Users")]
public class User
{
    [DynamoDBHashKey]
    public string Email { get; set; }

    [DynamoDBProperty]
    public string PasswordHash { get; set; }

    [DynamoDBProperty(StoreAsEpoch = true)]
    public DateTime CreatedAt { get; set; }
}