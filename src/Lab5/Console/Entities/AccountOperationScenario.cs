using System.Globalization;
using Console.Abstractions;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Models;
using Spectre.Console;

namespace Console.Entities;

public class AccountOperationScenario : IScenario
{
    private IAccountService _accountService;
    private IOperationsService _operationsService;
    private CurrentAccount _currentAccount;

    public AccountOperationScenario(IAccountService accountService, IOperationsService operationsService, CurrentAccount currentAccount)
    {
        _accountService = accountService;
        _operationsService = operationsService;
        _currentAccount = currentAccount;
        Name = "Account operations";
    }

    public string Name { get; }
    public void Run()
    {
        AnsiConsole.Clear();
        var operationDelegates = new List<ScenarioSubOperation>()
        {
            new ScenarioSubOperation(ShowBalance, "Show balance"),
            new ScenarioSubOperation(AccountOperations, "Show account operations"),
            new ScenarioSubOperation(ReplenishmentBalance, "Replenish balance"),
            new ScenarioSubOperation(WithdrawBalance, "Withdraw balance"),
        };

        SelectionPrompt<ScenarioSubOperation> selector = new SelectionPrompt<ScenarioSubOperation>()
            .Title("Select operation")
            .AddChoices(operationDelegates)
            .UseConverter(od => od.Name);

        ScenarioSubOperation subOperation = AnsiConsole.Prompt(selector);

        subOperation.OperationMethod();
    }

    private void ShowBalance()
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Can not find account");

        AnsiConsole.WriteLine($"Current balance: {_accountService.GetBalance(_currentAccount.Account.Id)}");

        _operationsService.AddOperation(_currentAccount.Account.Id, OperationType.Check, 0);

        AnsiConsole.Ask<string>("Ok");
    }

    private void AccountOperations()
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Can not find account");

        var operations =
            _operationsService.GetAccountOperations(_currentAccount.Account.Id).ToList();

        var table = new Table();

        table.AddColumn("Account Id").Ascii2Border();
        table.AddColumn("Operation type").Ascii2Border();
        table.AddColumn("balance").Ascii2Border();

        foreach (Operation operation in operations)
        {
            table.AddRow(
                operation.AccountId.ToString(CultureInfo.CurrentCulture),
                operation.AccountId.ToString(CultureInfo.CurrentCulture),
                operation.Balance.ToString(CultureInfo.CurrentCulture)).Ascii2Border();
        }

        AnsiConsole.Write(table);
        AnsiConsole.Ask<string>("Ok");
    }

    private void ReplenishmentBalance()
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Can not find account");

        decimal replenishmentAmount = AnsiConsole.Ask<decimal>("Input Replenishment amount: ");

        _accountService.UpdateBalance(_currentAccount.Account.Id, replenishmentAmount);

        _operationsService.AddOperation(_currentAccount.Account.Id, OperationType.Replenishment, replenishmentAmount);

        AnsiConsole.WriteLine($"Current balance: {_currentAccount.Account.Balance}");
        AnsiConsole.Ask<string>("Ok");
    }

    private void WithdrawBalance()
    {
        if (_currentAccount.Account is null)
            throw new ArgumentException("Can not find account");

        decimal withdrawAmount = AnsiConsole.Ask<decimal>("Input withdraw amount: ");

        Result result = _accountService.UpdateBalance(_currentAccount.Account.Id, -withdrawAmount);

        _operationsService.AddOperation(_currentAccount.Account.Id, OperationType.Withdraw, -withdrawAmount);

        switch (result)
        {
            case SuccessResult:
                AnsiConsole.WriteLine($"Residue balance: {_currentAccount.Account.Balance}");
                AnsiConsole.Ask<string>("Ok");
                break;
            case FailResult:
                AnsiConsole.WriteLine($"Insufficient balance");
                AnsiConsole.Ask<string>("Ok");
                break;
        }
    }
}