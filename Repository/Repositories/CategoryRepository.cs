using Dapper;
using Repository.Entities;

namespace Repository.Repositories;
public class CategoryRepository : ICategoryRepository
{
    private readonly IDbContext _dbContext;

    public CategoryRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"SELECT * FROM Categories ORDER BY id";

            return await connection.QueryAsync<Category>(sql);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryRepository.GetAllAsync", ex);
        }
    }

    public async Task<Category?> GetByIdAsync(int id)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"
                SELECT * FROM Categories WHERE id = @id
                SELECT * FROM Products WHERE CategoryId = @id";

            var result = await connection.QueryMultipleAsync(sql, new { id });
            var category = await result.ReadFirstOrDefaultAsync<Category>();
            if (category != null)
            {
                category.Products = (await result.ReadAsync<Product>()).ToList();
            }

            return category;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryRepository.GetByIdAsync", ex);
        }
    }

    public async Task<int> CreateAsync(Category category)
    {
        try
        {
            using var connection = _dbContext.Create();
            //string sql = @"
            //    INSERT INTO Categories (Name, Description, CreatedAt, UpdatedAt)
            //    VALUES (@Name, @Description, @CreatedAt, @UpdatedAt)";

            //var count = await connection.ExecuteAsync(sql, category);
            //return count;

            string sql = @"
                INSERT INTO Categories (Name, Description, CreatedAt, UpdatedAt)
                VALUES (@Name, @Description, @CreatedAt, @UpdatedAt);
                SELECT SCOPE_IDENTITY();";

            var categoryId = await connection.ExecuteScalarAsync<int>(sql, category);

            return categoryId;
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryRepository.CreateAsync", ex);
        }
    }
}
