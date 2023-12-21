using Console.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScenario(this IServiceCollection collection)
    {
        collection.AddScoped<AccountLoginScenario>();
        collection.AddScoped<AdminLoginScenario>();
        collection.AddScoped<CreateAccountScenario>();

        collection.AddScoped<StartScenario>();

        return collection;
    }
}