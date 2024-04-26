namespace WebApi.ViewModels;

public class PurchaseInfo
{
    public DateTime PurchaseDate { get; set; }
    public int VendorId { get; set; }
    public List<PurchaseItemInfo> PurchaseItems { get; set; } = new List<PurchaseItemInfo>();
}
