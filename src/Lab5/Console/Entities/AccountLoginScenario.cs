using Console.Abstractions;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Models;
using Spectre.Console;

namespace Console.Entities;

public class AccountLoginScenario : IScenario
{
    private IAccountService _accountService;
    private IOperationsService _operationsService;
    private CurrentAccount _currentAccount;

    public AccountLoginScenario(IAccountService accountService, IOperationsService operationsService, CurrentAccount currentAccount)
    {
        _accountService = accountService;
        _operationsService = operationsService;
        _currentAccount = currentAccount;
        Name = "Login account";
    }

    public string Name { get; }
    public void Run()
    {
        AnsiConsole.Clear();
        string name = AnsiConsole.Ask<string>("Enter your account name");
        int pin = AnsiConsole.Ask<int>("Enter your account pin");

        Result result = _accountService.GetAccount(name, pin);

        int accountId = 0;
        if (_currentAccount.Account is not null)
            accountId = _currentAccount.Account.Id;

        switch (result)
        {
            case SuccessResult:
                var accountOperation = new AccountOperationScenario(_accountService, _operationsService, _currentAccount);
                _operationsService.AddOperation(accountId, OperationType.Login, 0);
                accountOperation.Run();
                break;
            case FailResult:
                AnsiConsole.WriteLine("Fail to authorise account");
                AnsiConsole.Ask<string>("Ok");
                break;
        }
    }
}