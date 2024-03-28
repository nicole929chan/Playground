namespace Service.Dtos;

public class ProductUpdate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsDeleted { get; set; }
    public decimal? Price { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}