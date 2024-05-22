namespace Repository.Repositories;
public interface IUnitOfWork
{
    Task SaveChangesAsync<T>(T entity) where T : class;
}
