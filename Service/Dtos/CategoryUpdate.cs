namespace Service.Dtos;
public class CategoryUpdate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsDeleted { get; set; }
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
