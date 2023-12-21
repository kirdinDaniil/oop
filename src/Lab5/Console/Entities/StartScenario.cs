using Console.Abstractions;
using Spectre.Console;

namespace Console.Entities;

public class StartScenario
{
    private AdminLoginScenario _adminLoginScenario;
    private CreateAccountScenario _createAccountScenario;
    private AccountLoginScenario _accountLoginScenario;

    public StartScenario(AdminLoginScenario adminLoginScenario, CreateAccountScenario createAccountScenario, AccountLoginScenario accountLoginScenario)
    {
        _adminLoginScenario = adminLoginScenario;
        _createAccountScenario = createAccountScenario;
        _accountLoginScenario = accountLoginScenario;
    }

    public void Run()
    {
        var scenarios = new List<IScenario>()
        {
            _adminLoginScenario,
            _createAccountScenario,
            _accountLoginScenario,
        };

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title("Select operation")
            .AddChoices(scenarios)
            .UseConverter(s => s.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);

        scenario.Run();
    }
}