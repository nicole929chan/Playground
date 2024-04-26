using Dapper;
using Repository.Entities;

namespace Repository.Repositories;
public class PurchaseItemRepository : IPurchaseItemRepository
{
    private readonly IDbContext _dbContext;

    public PurchaseItemRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task CreateAsync(List<PurchaseItem> purchaseItems)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"
                INSERT INTO PurchaseItem (PurchaseId, ProductId, Sku, Quantity, Price, Amount, CreatedAt, UpdatedAt)
                VALUES (@PurchaseId, @ProductId, @Sku, @Quantity, @Price, @Amount, @CreatedAt, @UpdatedAt);";

            await connection.ExecuteAsync(sql, purchaseItems);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
