using Repository.Entities;

namespace Repository.Repositories;
public interface IProductRepository
{
    Task<Product?> GetByIdAsync(int id);
    Task<int> UpdateAsync(Product product);
}
