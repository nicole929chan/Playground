namespace WebApi.ViewModels;

public class PurchaseItemInfo
{
    public int ProductId { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}