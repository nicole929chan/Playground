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

    public Task<IEnumerable<Category>> GetAllAsync()
    {
        using var connection = _dbContext.Create();
        string sql = @"SELECT * FROM Categories";

        return connection.QueryAsync<Category>(sql);
    }
}
