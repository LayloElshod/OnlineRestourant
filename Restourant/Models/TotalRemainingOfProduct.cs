namespace Restourant.Models;

public class TotalRemainingOfProduct
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int TotalRemaining { get; set; }
    public Product Product { get; set; }
}
