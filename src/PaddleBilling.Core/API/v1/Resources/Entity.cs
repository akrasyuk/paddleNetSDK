namespace PaddleBilling.Core.API.v1.Resources;

public abstract class Entity
{
    public string Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}