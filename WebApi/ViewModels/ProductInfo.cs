namespace WebApi.ViewModels;

public class ProductInfo
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsDeleted { get; set; }
    public decimal? Price { get; set; }
}
