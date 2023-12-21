using DomainModel.Abstractions.Repositories;
using DomainModel.Abstractions.Services;
using DomainModel.Entities.CurrentModels;
using DomainModel.Entities.Records;
using DomainModel.Models;

namespace DomainModel.Entities.Services;

public class AdminService : IAdminService
{
    private readonly IAdminsRepository _repository;
    private CurrentAdmin _currentAdmin;

    public AdminService(IAdminsRepository repository, CurrentAdmin currentAdmin)
    {
        _repository = repository;
        _currentAdmin = currentAdmin;
    }

    public Result Login(int id, string password)
    {
        Admin? admin = _repository.GetAdmin(id, password);

        _currentAdmin.Admin = admin;

        return (admin is null) ? new FailResult() : new SuccessResult();
    }
}