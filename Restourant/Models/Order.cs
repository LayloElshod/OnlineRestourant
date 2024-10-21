namespace Restourant.Models;

public class Order
{
    public int Id { get; set; }
    public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public Employee Employee { get; set; }
    public int EmployeeId { get; set; }
    public int AdressId { get; set; }
    public Adress Adress { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public DateTime CreatedTime { get; set; }= DateTime.Now;
    public decimal TotalPrice { get; set; }

}
