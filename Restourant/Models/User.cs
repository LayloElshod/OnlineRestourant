using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Restourant.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string PhoneNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [JsonIgnore]
    //[DatabaseGenerated(DatabaseGeneratedOption.Computed)] kiritayotganimizda boglangan obyekt talab qilmaydi;
    public ICollection<UserAdress>? UserAdresses { get; set; }
    [JsonIgnore]
    public ICollection<Order>? Orders { get; set; }

}
