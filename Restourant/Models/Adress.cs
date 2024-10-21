using System.Text.Json.Serialization;

namespace Restourant.Models;

public class Adress
{
    public int Id { get; set; }
    public string Region { get; set; }
    public int  Home { get; set; }
    public int Floor { get; set; }
    public string  Location { get; set; }
    [JsonIgnore]
    public virtual ICollection<UserAdress>? UserAdresses { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order>? Orders { get; set; }


}
