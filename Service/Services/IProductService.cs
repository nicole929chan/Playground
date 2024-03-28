using Service.Dtos;

namespace Service.Services;
public interface IProductService
{
    Task<ProductResult?> GetByIdAsync(int id);
}
