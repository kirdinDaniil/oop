using DomainModel.Models;

namespace DomainModel.Abstractions.Repositories;

public interface IAccountsRepository
{
    public void CreateAccount(string name, int pin);

    public Account? GetAccount(string name, int pin);

    public decimal GetBalance(int id);

    public decimal UpdateBalance(int id, decimal newBalance);

    public Account? GetAccountById(int id);
}