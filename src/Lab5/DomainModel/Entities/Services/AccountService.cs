using DomainModel.Abstractions.Repositories;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Models;

namespace DomainModel.Entities.Services;

public class AccountService : IAccountService
{
    private readonly IAccountsRepository _repository;
    private CurrentAccount _currentAccount;

    public AccountService(CurrentAccount currentAccount, IAccountsRepository repository)
    {
        _currentAccount = currentAccount;
        _repository = repository;
    }

    public void AddAccount(string name, int pin)
    {
        _repository.CreateAccount(name, pin);
    }

    public Result GetAccount(string name, int pin)
    {
        Account? account = _repository.GetAccount(name, pin);

        _currentAccount.Account = account;

        return (account is null) ? new FailResult() : new SuccessResult();
    }

    public Result GetAccountById(int id)
    {
        Account? account = _repository.GetAccountById(id);

        _currentAccount.Account = account;

        return (account is null) ? new FailResult() : new SuccessResult();
    }

    public decimal GetBalance(int id)
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Account do not find");

        return _repository.GetBalance(_currentAccount.Account.Id);
    }

    public Result UpdateBalance(int id, decimal newBalance)
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Account do not find");

        if (_currentAccount.Account.Balance + newBalance < 0)
            return new FailResult();

        _repository.UpdateBalance(_currentAccount.Account.Id, _currentAccount.Account.Balance + newBalance);

        _currentAccount.Account = new Account(
            _currentAccount.Account.Id,
            _currentAccount.Account.Name,
            _currentAccount.Account.Pin,
            _currentAccount.Account.Balance + newBalance,
            _currentAccount.Account.IsActive);

        return new SuccessResult();
    }
}