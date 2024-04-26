using Dapper;
using Repository.Entities;

namespace Repository.Repositories;
public class PurchaseRepository : IPurchaseRepository
{
    private readonly IDbContext _dbContext;

    public PurchaseRepository(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Purchase?> GetByIdAsync(int id)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"
                SELECT * FROM Purchase WHERE Id = @id;
                SELECT * FROM PurchaseItem WHERE PurchaseId = @id";

            var result = await connection.QueryMultipleAsync(sql, new { id });
            var purchase = await result.ReadFirstOrDefaultAsync<Purchase>();
            if (purchase != null)
            {
                purchase.PurchaseItems = (await result.ReadAsync<PurchaseItem>()).ToList();
            }

            return purchase;

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<int> CreateAsync(Purchase purchase)
    {
        try
        {
            using var connection = _dbContext.Create();
            string sql = @"
                INSERT INTO Purchase (PurchaseNumber, PurchaseDate, VendorId, Status, TotalAmount, CreatedAt, UpdatedAt)
                VALUES (@PurchaseNumber, @PurchaseDate, @VendorId, @Status, @TotalAmount, @CreatedAt, @UpdatedAt);
                SELECT SCOPE_IDENTITY();";

            return await connection.ExecuteScalarAsync<int>(sql, purchase);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
