using sgi_app.domain.factory;

namespace sgi_app.infrastructure.mysql;

public class ConnDbFactory : IDbFactory
{
    private readonly string _connectionString;

    public ConnDbFactory(string connectionString)
    {
        _connectionString = connectionString;
    }

}   