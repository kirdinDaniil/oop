using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DomainModel.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBusinessLogic(this IServiceCollection collection)
    {
        collection.AddScoped<IAdminService, AdminService>();
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IOperationsService, OperationsService>();

        collection.AddScoped<CurrentAdmin>();
        collection.AddScoped<CurrentAccount>();
        collection.AddScoped<CurrentOperation>();

        return collection;
    }
}