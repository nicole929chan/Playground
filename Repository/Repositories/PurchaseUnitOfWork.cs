using Dapper;
using Repository.Entities;

namespace Repository.Repositories
{
    public class PurchaseUnitOfWork : IUnitOfWork
    {
        private readonly IDbContext _dbContext;

        public PurchaseUnitOfWork(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SaveChangesAsync(Purchase purchase, IEnumerable<PurchaseItem> purchaseItems)
        {
            using var connection = _dbContext.Create();
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                // Insert into Purchase table and get the new PurchaseId
                string purchaseSql = @"
                    INSERT INTO Purchase (PurchaseNumber, PurchaseDate, VendorId, Status, TotalAmount, CreatedAt, UpdatedAt)
                    VALUES (@PurchaseNumber, @PurchaseDate, @VendorId, @Status, @TotalAmount, @CreatedAt, @UpdatedAt);
                    SELECT SCOPE_IDENTITY();";

                purchase.Id = await connection.ExecuteScalarAsync<int>(purchaseSql, purchase, transaction);

                // Insert into PurchaseItem table
                string purchaseItemSql = @"
                    INSERT INTO PurchaseItem (PurchaseId, ProductId, Sku, Quantity, Price, Amount, CreatedAt, UpdatedAt)
                    VALUES (@PurchaseId, @ProductId, @Sku, @Quantity, @Price, @Amount, @CreatedAt, @UpdatedAt);";

                foreach (var item in purchaseItems)
                {
                    item.PurchaseId = purchase.Id; // Set the PurchaseId for each item
                }

                await connection.ExecuteAsync(purchaseItemSql, purchaseItems, transaction);

                // Commit transaction
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
