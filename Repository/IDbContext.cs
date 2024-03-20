using System.Data;

namespace Repository;
public interface IDbContext
{
    public IDbConnection Create();
}
