
using SignalR_Entities.Concrete;

namespace SignalRWebUI.Models.Dtos.BasketDto;

public class ResultBasketDto
{
    public int BasketID { get; set; }
    public decimal Price { get; set; }
    public decimal Count { get; set; }
    public decimal TotalPrice { get; set; }
    public int ProductID { get; set; }
    
    public Product Product { get; set; }
    
    public int MenuTableID { get; set; }
    
    public string MenuTableName { get; set; }
}