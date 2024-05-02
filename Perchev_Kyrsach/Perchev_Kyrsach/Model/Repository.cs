using Dapper;
using Microsoft.Data.Sqlite;

namespace Perchev_Kyrsach.Model;

public class Repository : IDisposable, IAsyncDisposable
{
    public Repository(string path, string options = "")
    {
        _connection = new SqliteConnection($"Data Source={path};{options}");
    }

    public void Save(User user)
    {
        string sql = "insert into Users (name, points) values (@Name, @Points)";
        _connection.Execute(sql, user);
    }

    public IEnumerable<User> Load()
    {
        string sql = "select * from Users order by points limit 10";
        return _connection.Query<User>(sql);
    }

    public void Dispose()
    {
        _connection.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _connection.DisposeAsync();
    }

    private SqliteConnection _connection;
}