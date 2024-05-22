

using System.Data;

namespace Repository.Repositories;
public abstract class UnitOfWork : IUnitOfWork
{
    protected readonly IDbContext _dbContext;

    protected UnitOfWork(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task SaveChangesAsync<T>(T entity) where T : class
    {
        using var connection = _dbContext.Create();
        connection.Open();
        using var transaction = connection.BeginTransaction();
        try
        {
            await SaveEntitiesAsync(connection, transaction, entity);
            transaction.Commit();
        }
        catch (Exception)
        {
            transaction.Rollback();
            throw;
        }
    }

    protected abstract Task SaveEntitiesAsync<T>(IDbConnection connection, IDbTransaction dbTransaction, T entity) where T : class;
}
