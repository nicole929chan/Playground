namespace Service.Dtos;

public class PurchaseItemCreate
{
    public int ProductId { get; set; }
    public string Sku { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}