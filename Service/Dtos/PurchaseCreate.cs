namespace Service.Dtos;
public class PurchaseCreate
{
    public DateTime PurchaseDate { get; set; }
    public int VendorId { get; set; }
    public List<PurchaseItemCreate> PurchaseItems { get; set; } = new List<PurchaseItemCreate>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
