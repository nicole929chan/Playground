using Repository.Entities;

namespace Repository.Repositories;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<int> CreateAsync(Category category);
    Task<int> UpdateAsync(Category category);
    //Task<Category> DeleteAsync(int id);
}
