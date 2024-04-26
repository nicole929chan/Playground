namespace Service.Dtos;
public class PurchaseResult
{
    public int Id { get; set; }
    public string PurchaseNumber { get; set; } = string.Empty;
    public DateTime PurchaseDate { get; set; }
    public int VendorId { get; set; }
    public decimal TotalAmount { get; set; }
    public List<PurchaseItemResult> PurchaseItems { get; set; } = new List<PurchaseItemResult>();
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
