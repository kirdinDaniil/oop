using Console.Abstractions;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Models;
using Spectre.Console;

namespace Console.Entities;

public class AdminAccessScenario : IScenario
{
    private IAccountService _accountService;
    private IOperationsService _operationsService;
    private CurrentAccount _currentAccount;

    public AdminAccessScenario(IAccountService accountService, IOperationsService operationsService, CurrentAccount currentAccount)
    {
        _accountService = accountService;
        _operationsService = operationsService;
        _currentAccount = currentAccount;
        Name = "Admin access";
    }

    public string Name { get; }
    public void Run()
    {
        AnsiConsole.Clear();

        int id = AnsiConsole.Ask<int>("Input suggested account id: ");

        Result result = _accountService.GetAccountById(id);

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