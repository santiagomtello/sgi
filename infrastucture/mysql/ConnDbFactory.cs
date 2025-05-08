using sgi.domain.factory;

namespace sgi.infrastructure.mysql;

public class ConnDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public ConnDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

}   