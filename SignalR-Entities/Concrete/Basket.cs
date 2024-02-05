using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR_Entities.Concrete;

public class Basket
{
    public int BasketID { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal Count { get; set; }
    
    public decimal TotalPrice { get; set; }
    
    [ForeignKey("Product")]
    public int ProductID { get; set; }
    
    public Product Product { get; set; }
    
    [ForeignKey("MenuTable")]
    public int MenuTableID { get; set; }
    
    public MenuTable MenuTable { get; set; }
    
}