namespace Restourant.Models;

public class UserAdress
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int AdressId { get; set; }
    public User User { get; set; }
    public Adress Adress { get; set; }
}
