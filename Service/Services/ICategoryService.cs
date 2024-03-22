using Service.Dtos;

namespace Service.Services;
public interface ICategoryService
{
    Task<IEnumerable<CategoryResult>> GetAllAsync();
    Task<CategoryResult?> GetByIdAsync(int id);
    Task<int> CreateAsync(CategoryCreate category);
    //Task<CategoryResult> UpdateAsync(CategoryResult category);
    //Task<CategoryResult> DeleteAsync(int id);
}
