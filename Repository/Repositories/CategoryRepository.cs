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
        //try
        //{
        //    using var connection = _dbContext.Create();
        //    string sql = @"
        //        SELECT * FROM Categories WHERE id = @id
        //        SELECT * FROM Products WHERE CategoryId = @id";

        //    var result = await connection.QueryMultipleAsync(sql, new { id });
        //    var category = await result.ReadFirstOrDefaultAsync<Category>();
        //    if (category != null)
        //    {
        //        category.Products = (await result.ReadAsync<Product>()).ToList();
        //    }

        //    return category;
        //}
        //catch (Exception ex)
        //{
        //    throw new Exception("Error in CategoryRepository.GetByIdAsync", ex);
        //}

        try
        {
            using var connection = _dbContext.Create();

            var data = new Dictionary<int, Category>();

            string sql = @"
                SELECT P.*, C.*  
                FROM Categories AS C inner join Products AS P ON C.Id = P.CategoryId
                WHERE C.Id = @id";
            await connection.QueryAsync<Product, Category, Category>(sql, (product, category) =>
            {
                if (data.TryGetValue(category.Id, out var existingCategory))
                {
                    category = existingCategory;
                }
                else
                {
                    data.Add(category.Id, category);
                }

                category.Products.Add(product);

                return category;

            }, new { id }, splitOn: "Id");  // 此處的 splitOn: "Id" 是指定分割點，C與P都有Id，取第一個出現(P.Id)

            return data[id];
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

    public async Task<int> UpdateAsync(Category category)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"
                UPDATE Categories
                SET Name = @Name, Description = @Description, IsDeleted = @IsDeleted, UpdatedAt = @UpdatedAt
                WHERE Id = @Id";

            return await connection.ExecuteAsync(sql, category);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryRepository.UpdateAsync", ex);
        }
    }

    public async Task<int> DeleteAsync(int id)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"SELECT * FROM Products WHERE CategoryId = @id";

            var products = await connection.QueryAsync<Product>(sql, new { id });
            if (products.Count() > 0)
            {
                sql = "UPDATE Products SET CategoryId = NULL WHERE CategoryId = @id";
                await connection.ExecuteAsync(sql, new { id });
            }

            sql = @"DELETE FROM Categories WHERE Id = @Id";

            return await connection.ExecuteAsync(sql, new { Id = id });
        }
        catch (Exception ex)
        {
            throw new Exception("Error in CategoryRepository.DeleteAsync", ex);
        }
    }
}
