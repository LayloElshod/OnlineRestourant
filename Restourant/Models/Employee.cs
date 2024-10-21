using System.Text.Json.Serialization;

namespace Restourant.Models;

public class Employee
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal CurrentSalary { get; set; }
    [JsonIgnore]
    public virtual ICollection<Order>? Orders { get; set; }
}
