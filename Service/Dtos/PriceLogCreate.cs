namespace Service.Dtos;
public class PriceLogCreate
{
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; }
}
