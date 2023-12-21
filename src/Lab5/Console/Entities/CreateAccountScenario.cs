using Console.Abstractions;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Models;
using Spectre.Console;

namespace Console.Entities;

public class CreateAccountScenario : IScenario
{
    private IAccountService _accountService;
    private IOperationsService _operationsService;
    private CurrentAccount _currentAccount;

    public CreateAccountScenario(IAccountService accountService, IOperationsService operationsService, CurrentAccount currentAccount)
    {
        _accountService = accountService;
        _operationsService = operationsService;
        _currentAccount = currentAccount;
        Name = "Create account";
    }

    public string Name { get; }
    public void Run()
    {
        AnsiConsole.Clear();

        string name = AnsiConsole.Ask<string>("Input account name: ");
        int pin = AnsiConsole.Ask<int>("Input pin name: ");

        _accountService.AddAccount(name, pin);

        if (_currentAccount.Account is null)
            throw new ArgumentException("Fail account creation");

        _operationsService.AddOperation(_currentAccount.Account.Id, OperationType.Creation, 0);
    }
}