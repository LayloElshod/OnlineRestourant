using System.Text.Json.Serialization;

namespace Restourant.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string Description { get; set; }
    public DateOnly ProductionDate { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; }
    [JsonIgnore]
    public TotalRemainingOfProduct? Total { get; set; }
    [JsonIgnore]
    public ICollection<OrderProduct>? OrderProducts { get; set; }
}
