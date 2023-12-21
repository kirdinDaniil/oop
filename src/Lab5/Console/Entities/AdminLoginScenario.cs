using Console.Abstractions;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using Spectre.Console;

namespace Console.Entities;

public class AdminLoginScenario : IScenario
{
    private IAccountService _accountService;
    private IOperationsService _operationsService;
    private IAdminService _adminService;
    private CurrentAccount _currentAccount;

    public AdminLoginScenario(IAccountService accountService, IOperationsService operationsService, IAdminService adminService, CurrentAccount currentAccount)
    {
        _accountService = accountService;
        _operationsService = operationsService;
        _adminService = adminService;
        _currentAccount = currentAccount;
        Name = "Login Admin";
    }

    public string Name { get; }
    public void Run()
    {
        AnsiConsole.Clear();
        int id = AnsiConsole.Ask<int>("Enter your admin id");
        string password = AnsiConsole.Ask<string>("Enter your admin password");

        Result result = _adminService.Login(id, password);

        switch (result)
        {
            case SuccessResult:
                var nextScenario = new AdminAccessScenario(_accountService, _operationsService, _currentAccount);
                nextScenario.Run();
                break;
            case FailResult:
                AnsiConsole.WriteLine("Fail to authorise admin");
                AnsiConsole.Ask<string>("Ok");
                break;
        }
    }
}