using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.SqlServer;
public class SqlServerConnection : IDbContext
{
    private readonly string? _connectionString;

    public SqlServerConnection(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }
    public IDbConnection Create()
    {
        return new SqlConnection(_connectionString);
    }
}
