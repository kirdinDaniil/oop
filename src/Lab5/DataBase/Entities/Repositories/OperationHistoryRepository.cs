using DomainModel.Abstractions.Repositories;
using DomainModel.Models;
using Npgsql;

namespace DataBase.Entities;

public sealed class OperationHistoryRepository : IOperationHistoryRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public OperationHistoryRepository(Connection connection)
    {
        if (connection is null)
            throw new ArgumentException("Connection can not be null");

        string connectionText = $"Host={connection.Host};Port={connection.Port};Username={connection.Username};Password={connection.Password};Database={connection.Db}";
        _connection = new NpgsqlConnection(connectionText);
        _connection.Open();
    }

    ~OperationHistoryRepository()
    {
        Dispose(false);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public void CreateOperation(int accountId, OperationType type, decimal balance)
    {
        string sql = $"insert into operations_history values ({accountId}, {(int)type}, {balance})";

        using var command = new NpgsqlCommand(sql, _connection);

        command.ExecuteNonQuery();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public IEnumerable<Operation> GetOperations(int accountId)
    {
        string sql = $"select * from operations_history where account_id = {accountId}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        while (reader.Read())
        {
            yield return new Operation(
                reader.GetInt32(0),
                (OperationType)reader.GetInt32(1),
                reader.GetDecimal(3));
        }
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