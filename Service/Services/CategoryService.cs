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

    public async Task<CategoryResult?> GetByIdAsync(int id)
    {
        try
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null)
            {
                return null;
            }
            return new CategoryResult
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                IsDeleted = category.IsDeleted,
                CreatedAt = category.CreatedAt,
                UpdatedAt = category.UpdatedAt,
                Products = category.Products.Select(p => new ProductResult
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                    IsDeleted = p.IsDeleted,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    CategoryId = p.CategoryId
                }).ToList()
            };
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryService.GetByIdAsync", ex);
        }
    }
}
