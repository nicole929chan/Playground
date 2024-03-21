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
}
