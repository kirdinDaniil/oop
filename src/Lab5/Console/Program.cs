using Console.Entities;
using Console.Extensions;
using DataBase.Extensions;
using DomainModel.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;

namespace Console;

public static class Program
{
    public static void Main()
    {
        IServiceCollection collection = new ServiceCollection()
            .AddStandardConnection()
            .AddBusinessLogic()
            .AddScenario();

        IServiceProvider provider = collection.BuildServiceProvider();

        using IServiceScope scope = provider.CreateScope();

        StartScenario? startScenario = provider.GetService<StartScenario>();

        if (startScenario is null)
            throw new ArgumentException("bad connection");

        while (true)
        {
            startScenario.Run();
            AnsiConsole.Clear();
        }
    }
}