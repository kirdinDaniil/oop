using DomainModel.Entities.Records;

namespace DomainModel.Abstractions.Services;

public interface IAccountService
{
    public void AddAccount(string name, int pin);

    public Result GetAccount(string name, int pin);

    public decimal GetBalance(int id);

    public Result UpdateBalance(int id, decimal newBalance);

    public Result GetAccountById(int id);
}