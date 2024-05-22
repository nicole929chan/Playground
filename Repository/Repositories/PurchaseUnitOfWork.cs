using Dapper;
using Repository;
using Repository.Entities;
using Repository.Repositories;
using System.Data;

public class PurchaseUnitOfWork : UnitOfWork
{
    public PurchaseUnitOfWork(IDbContext dbContext) : base(dbContext) { }

    protected override async Task SaveEntitiesAsync<TEntity>(IDbConnection connection, IDbTransaction transaction, TEntity entity)
    {
        if (entity is Purchase purchase)
        {
            // Insert Purchase and get the new PurchaseId
            string purchaseSql = @"
                INSERT INTO Purchase (PurchaseNumber, PurchaseDate, VendorId, Status, TotalAmount, CreatedAt, UpdatedAt)
                VALUES (@PurchaseNumber, @PurchaseDate, @VendorId, @Status, @TotalAmount, @CreatedAt, @UpdatedAt);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            purchase.Id = await connection.ExecuteScalarAsync<int>(purchaseSql, purchase, transaction);

            // Insert PurchaseItems
            string purchaseItemSql = @"
                INSERT INTO PurchaseItem (PurchaseId, ProductId, Sku, Quantity, Price, Amount, CreatedAt, UpdatedAt)
                VALUES (@PurchaseId, @ProductId, @Sku, @Quantity, @Price, @Amount, @CreatedAt, @UpdatedAt);";

            foreach (var item in purchase.PurchaseItems)
            {
                item.PurchaseId = purchase.Id;
            }

            await connection.ExecuteAsync(purchaseItemSql, purchase.PurchaseItems, transaction);
        }
        else
        {
            throw new InvalidOperationException("Unsupported entity type");
        }
    }
}
