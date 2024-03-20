using Repository.Entities;

namespace Repository.Repositories;
public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllAsync();
    //Task<Category> GetByIdAsync(int id);
    //Task<Category> CreateAsync(Category category);
    //Task<Category> UpdateAsync(Category category);
    //Task<Category> DeleteAsync(int id);
}
