using DomainModel.Entities.Records;

namespace DomainModel.Abstractions.Services;

public interface IAdminService
{
    public Result Login(int id, string password);
}