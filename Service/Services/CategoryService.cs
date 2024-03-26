using Repository.Entities;
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

    public async Task<int> CreateAsync(CategoryCreate category)
    {
        var result = await _categoryRepository.CreateAsync(new Category
        {
            Name = category.Name,
            Description = category.Description,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt
        });

        return result;
    }

    public async Task<int> UpdateAsync(CategoryUpdate category)
    {
        try
        {
            var entity = await _categoryRepository.GetByIdAsync(category.Id);
            if (entity == null)
            {
                throw new Exception("Category not found");
            }

            entity.Name = category.Name;
            entity.Description = category.Description;
            entity.IsDeleted = (bool)category.IsDeleted;
            entity.UpdatedAt = category.UpdatedAt;

            var result = await _categoryRepository.UpdateAsync(entity);
            return result;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryService.UpdateAsync", ex);
        }
    }

    //Task<CategoryResult> 9CreateAsync(CategoryCreateRequest category)
    //{
    //    throw new NotImplementedException();
    //}
}
