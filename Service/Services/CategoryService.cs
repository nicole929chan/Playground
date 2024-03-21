using Repository.Repositories;
using Service.Dtos;

namespace Service.Services;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }
    public async Task<IEnumerable<CategoryResult>> GetAllAsync()
    {
        try
        {
            var categories = await _categoryRepository.GetAllAsync();
            return categories.Select(c => new CategoryResult
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                IsDeleted = c.IsDeleted,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            });
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryService.GetAllAsync", ex);
        }
    }
}
