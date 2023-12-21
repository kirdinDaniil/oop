using DomainModel.Models;

namespace DomainModel.Abstractions.Repositories;

public interface IAdminsRepository
{
    public Admin? GetAdmin(int id, string password);
}