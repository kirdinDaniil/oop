using DataBase.Entities;
using DomainModel.Abstractions.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DataBase.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStandardConnection(this IServiceCollection collection)
    {
        collection.AddScoped<Connection, StandardConnection>();

        collection.AddScoped<IAccountsRepository, AccountsRepository>();
        collection.AddScoped<IAdminsRepository, AdminsRepository>();
        collection.AddScoped<IOperationHistoryRepository, OperationHistoryRepository>();

        return collection;
    }
}