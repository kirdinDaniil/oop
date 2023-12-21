using DomainModel.Abstractions.Repositories;
using DomainModel.Models;
using Npgsql;

namespace DataBase.Entities;

public sealed class AdminsRepository : IAdminsRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public AdminsRepository(Connection connection)
    {
        if (connection is null)
            throw new ArgumentException("Connection can not be null");

        string connectionText = $"Host={connection.Host};Port={connection.Port};Username={connection.Username};Password={connection.Password};Database={connection.Db}";
        _connection = new NpgsqlConnection(connectionText);
        _connection.Open();
    }

    ~AdminsRepository()
    {
        Dispose(false);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public Admin? GetAdmin(int id, string password)
    {
        string sql = $"select admin_id, admin_password from admins where admin_password = {password}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Admin(
            reader.GetInt32(0),
            reader.GetString(1));
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool disposing)
    {
        if (!disposing) return;
        _connection.Close();
        _connection.Dispose();
    }
}