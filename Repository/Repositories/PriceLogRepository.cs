using Dapper;
using Repository.Entities;

namespace Repository.Repositories;
public class PriceLogRepository : IPriceLogRepository
{
    private readonly IDbContext _dbContext;

    public PriceLogRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<int> AddAsync(PriceLog priceLog)
    {
        try
        {
            using var connection = _dbContext.Create();
            var sql = @"
                INSERT INTO PriceLog (ProductId, UserId, OldPrice, NewPrice, Reason, CreatedAt)
                VALUES (@ProductId, @UserId, @OldPrice, @NewPrice, @Reason, @CreatedAt);
                SELECT SCOPE_IDENTITY();";

            return await connection.ExecuteScalarAsync<int>(sql, priceLog);
        }
        catch (Exception ex)
        {
            throw new Exception("Error in PriceLogRepository.AddAsync", ex);
        }
    }
}
