using DomainModel.Abstractions.Repositories;
using DomainModel.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests.Moks;

public class AccountRepositoryMock : IAccountsRepository
{
    public void CreateAccount(string name, int pin)
    {
    }

    public Account? GetAccount(string name, int pin)
        => new Account(1, "1", 1, 200, true);

    public decimal GetBalance(int id)
        => 1;

    public decimal UpdateBalance(int id, decimal newBalance)
        => newBalance;

    public Account? GetAccountById(int id)
        => new Account(1, "1", 1, 200, true);
}