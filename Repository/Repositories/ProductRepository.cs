using Dapper;
using Repository.Entities;

namespace Repository.Repositories;
public class ProductRepository : IProductRepository
{
    private readonly IDbContext _dbContext;

    public ProductRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Product?> GetByIdAsync(int id)
    {
        try
        {
            var connection = _dbContext.Create();

            string sql = @"SELECT * FROM Products WHERE Id = @Id";
            var product = await connection.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });

            return product;

        }
        catch (Exception ex)
        {
            throw new Exception("Error in ProductRepository.GetByIdAsync", ex);
        }
    }
}
