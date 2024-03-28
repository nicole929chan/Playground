namespace Repository.Entities;
public class PriceLog
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int UserId { get; set; }
    public decimal OldPrice { get; set; }
    public decimal NewPrice { get; set; }
    public string? Reason { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
