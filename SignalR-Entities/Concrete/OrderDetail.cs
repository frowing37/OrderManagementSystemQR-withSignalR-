namespace SignalR_Entities.Concrete;

public class OrderDetail
{
    public int OrderDetailID { get; set; }
    
    public int ProductID { get; set; }
    
    public Product Product { get; set; }
    
    public int Count { get; set; }
    
    public int UnitPrice { get; set; }
    
    public int TotalPrice { get; set; }
    
    public int OrderID { get; set; }
    
    public Order Order { get; set; }
}