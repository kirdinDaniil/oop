using DomainModel.Abstractions.Repositories;
using DomainModel.Models;
using Npgsql;

namespace DataBase.Entities;

public sealed class AccountsRepository : IAccountsRepository, IDisposable
{
    private readonly NpgsqlConnection _connection;

    public AccountsRepository(Connection connection)
    {
        if (connection is null)
            throw new ArgumentException("Connection can not be null");

        string connectionText = $"Host={connection.Host};Port={connection.Port};Username={connection.Username};Password={connection.Password};Database={connection.Db}";
        _connection = new NpgsqlConnection(connectionText);
        _connection.Open();
    }

    ~AccountsRepository()
    {
        Dispose(false);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public void CreateAccount(string name, int pin)
    {
        string sql = $"insert into accounts values ({name}, {pin}, 0, true";

        using var command = new NpgsqlCommand(sql, _connection);

        command.ExecuteNonQuery();
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public Account? GetAccount(string name, int pin)
    {
        string sql = $"select * from accounts where account_name = {name} and account_pin = {pin}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetInt32(2),
            reader.GetDecimal(3),
            reader.GetBoolean(4));
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public Account? GetAccountById(int id)
    {
        string sql = $"select * from accounts where account_id = {id}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read() is false)
            return null;

        return new Account(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetInt32(2),
            reader.GetDecimal(3),
            reader.GetBoolean(4));
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public decimal GetBalance(int id)
    {
        string sql = $"select balance from accounts where account_id = {id}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.GetDecimal(3);
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "Method already uses a Stored Procedure")]
    public decimal UpdateBalance(int id, decimal newBalance)
    {
        string sql = $"update accounts set balance = {newBalance} where account_id = {id}";

        using var updateCommand = new NpgsqlCommand(sql, _connection);

        updateCommand.ExecuteNonQuery();

        sql = $"select balance from accounts where account_id = {id}";

        using var command = new NpgsqlCommand(sql, _connection);

        using NpgsqlDataReader reader = command.ExecuteReader();

        return reader.GetDecimal(3);
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