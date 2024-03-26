using Service.Dtos;

namespace Service.Services;
public interface ICategoryService
{
    Task<IEnumerable<CategoryResult>> GetAllAsync();
    Task<CategoryResult?> GetByIdAsync(int id);
    Task<int> CreateAsync(CategoryCreate category);
    Task<int> UpdateAsync(CategoryUpdate category);
    Task<int> DeleteAsync(int id);
}
