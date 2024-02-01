using System.Runtime.InteropServices.JavaScript;

namespace SignalR_Entities.Concrete;

public class Order
{
    public int OrderID { get; set; }
    
    public int TableNumber { get; set; }
    
    public string Description { get; set; }
    
    public DateTime Date { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    public List<OrderDetail> OrderDetails { get; set; }
}