using System.ComponentModel.DataAnnotations.Schema;

namespace SignalR_Entities.Concrete;

public class ProductDiscount
{
    public int ID { get; set; }
    
    [ForeignKey("Product")]
    public int ProductID { get; set; }
    
    public Product Product { get; set; }
    
    [ForeignKey("Discount")]
    public int DiscountID { get; set; }
    
    public Discount Discount { get; set; }
}